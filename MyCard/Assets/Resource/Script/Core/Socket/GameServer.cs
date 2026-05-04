using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;

namespace Assets.Resource.Script.Core.Socket
{
	public class GameServer
	{
		private TcpListener listener;
		private int port;
		private bool isRunning;
		private List<TcpClient> clients;
		private object lockclient;
		private Action<TcpClient, string> processMessageFunc;
		public GameServer()
		{
			listener = null;
			port = 9093;
			isRunning = false;
			lockclient = new object();
			clients = new List<TcpClient>();
			processMessageFunc = null;
		}
		public void BindMessageFunc(Action<TcpClient, string> processMessageFunc)
		{ 
			this.processMessageFunc = processMessageFunc;
		}
		public void Stop()
		{
			listener.Stop();
			isRunning = false;
			Log.Debug("服务已经关闭");
		}
		/// <summary>
		/// 给当前的所有客户端进行广播通知
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public void BroadcastAll(string message)
		{
			Log.Debug($"服务器广播发送消息：{message}");
			byte[] data = Encoding.UTF8.GetBytes(message);
			lock (lockclient)
			{
				foreach (var client in clients)
				{
					if (client == null) continue;
					try
					{
						if (client.Connected)
						{
							var stream = client.GetStream();
							stream.Write(data, 0, data.Length);
						}
					}
					catch (Exception e)
					{
						Log.Debug($"发送给客户端失败：{e.Message}");
					}
				}
			}
		}
		/// <summary>
		/// 每一个客户端触发消息的时候调用
		/// </summary>
		/// <param name="client"></param>
		/// <returns></returns>
		private void HandleClient(TcpClient client) 
		{
			using (var stream = client.GetStream())
			{
				var buffer = new byte[4096];

				while (isRunning && client != null && client.Connected)
				{
					try
					{
						// 异步读取（不阻塞线程，但当前方法会挂起等待）
						int bytesRead = stream.Read(buffer, 0, buffer.Length);
						if (bytesRead == 0)
						{
							// 客户端正常关闭连接
							Log.Debug("客户端已断开连接");
							break;
						}
						// 处理接收到的数据
						byte[] receivedData = new byte[bytesRead];
						Array.Copy(buffer, 0, receivedData, 0, bytesRead);
						// 处理消息
						if(processMessageFunc != null) 
							processMessageFunc(client,Encoding.UTF8.GetString(receivedData));
					}
					catch (IOException ex)
					{
						// 网络异常或连接断开
						Log.Debug($"连接异常: {ex.Message}");
						break;
					}
					catch (Exception ex)
					{
						Log.Debug($"处理消息错误: {ex.Message}");
					}
				}
			}
			RemoveClinet(client);
		}
		public void RemoveClinet(TcpClient client)
		{
			lock (lockclient)
			{
				if (!clients.Contains(client))
				{
					clients.Remove(client);
					client.Dispose();
				}
			}
		}
		public void PushClient(TcpClient client)
		{
			lock (lockclient)
			{
				if (!clients.Contains(client))
				{
					clients.Add(client);
				}
			}
		}
		public bool Start()
			{
				try
				{
					IPAddress localIp = IPAddress.Parse("127.0.0.1");
					listener = new TcpListener(localIp, port);
					listener.Start();
					isRunning = true;
					Log.Debug($"服务器已启动，端口:{port}");
				}
				catch (Exception e)
				{
					isRunning = false;
					return false;
				}
				//任务处理
				Task.Run(async () =>  {
					while (isRunning)
					{
						try
						{
							//有新的客户端连接的时候触发
							var client = await listener.AcceptTcpClientAsync();
							var endPoint = client.Client.RemoteEndPoint as System.Net.IPEndPoint;
							string clientIP = endPoint.Address.ToString();
							int clientPort = endPoint.Port;
							Log.Debug($"客户端连接: {clientIP}:{clientPort}");
							PushClient(client);
							_ = Task.Run(()=> HandleClient(client));
						}
						catch (ObjectDisposedException)
						{
							// listener 被关闭，正常退出
							break;
						}
						catch (Exception e)
						{
							await Task.Delay(1000); // 避免异常时疯狂循环
						}
					}
				});
				return true;
			}
		}
}

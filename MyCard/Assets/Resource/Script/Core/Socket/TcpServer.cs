using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
/*
 消息机制定义:1.后续消息队列长度 2.消息类型 3.数据
 */
namespace Assets.Resource.Script.Core.Socket
{
	public class TcpServer
	{
		private TcpListener listener;
		private int port;
		private bool isRunning;
		private List<TcpClient> clients;
		private object lockclient;
		public TcpServer()
		{
			listener = null;
			port = 9093;
			isRunning = false;
			lockclient = new object();
		}
		public void Stop()
		{
			listener.Stop();
			isRunning = false;
			Log.Debug("服务已经关闭");
		}
		/// <summary>
		/// 每一个客户端触发消息的时候调用
		/// </summary>
		/// <param name="client"></param>
		/// <returns></returns>
		private async Task HandleClientAsync(TcpClient client) 
		{
			using (client)
			using (var stream = client.GetStream())
			{
				var buffer = new byte[4];//先读取头数据
				while (isRunning && client != null &&
					client.Connected) { 
					
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
							Console.WriteLine($"客户端连接: {clientIP}:{clientPort}");
							PushClient(client);
							_ = Task.Run(()=> HandleClientAsync(client));
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

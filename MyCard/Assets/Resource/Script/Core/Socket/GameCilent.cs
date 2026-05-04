using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
namespace Assets.Resource.Script.Core.Socket
{
	public class GameCilent
	{
		public TcpClient Client { get; set; }
		//private int Ip { get; set; } //IP地址
		private int Port { get; set; } //端口号
		private NetworkStream Stream { get; set; }
		public string LocalAddress { get; private set; }

		public int LocalPort { get; private set; }

		private Action<string> processMessageFunc;
		public GameCilent()
		{
			Client = new TcpClient();
			Stream = null;
			//Ip = 127.0.0.1;
			Port = 9093;
			LocalPort = 0;
			LocalAddress = "";
		}
		public void BindMessageFunc(Action<string> processMessageFunc)
		{
			this.processMessageFunc = processMessageFunc;
		}
		public bool Connect()
		{
			try
			{
				IPAddress localIp = IPAddress.Parse("127.0.0.1");
				Client.Connect(localIp, Port);
				Stream = Client.GetStream();
				var localEndPoint = Client.Client.LocalEndPoint as IPEndPoint;
				if (localEndPoint != null)
				{
					LocalPort = localEndPoint.Port;
					LocalAddress = localEndPoint.Address.ToString();
					Debug.Log($"客户端连接成功！本地端口: {LocalPort}, 本地地址: {LocalAddress}");
				}
				_ = Task.Run(() => ReceiveMessageLoop());
				return true;
			}
			catch (Exception e)
			{
				Debug.Log($"客户端连接失败: {e.Message}");
				return false;
			}
		}

		private async Task ReceiveMessageLoop()
		{
			var buffer = new byte[1024];
			while (Client.Connected) {
				try
				{
					//等待消息直到服务器返回
					int bytesRead = await Stream.ReadAsync(buffer, 0, buffer.Length);
					if (bytesRead == 0)
					{
						Debug.Log("服务器断开连接");
						break;
					}
					string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
					if (processMessageFunc != null)
						processMessageFunc(message);
				}
				catch (IOException e)
				{
					Debug.Log($"网络错误：{e.Message}");
					break;
				}
				catch (Exception e)
				{
					Debug.Log($"接收异常：{e.Message}");
					break;
				}
			}

		}
		/// <summary>
		/// 异步发送消息
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public void SendMessage(string message)
		{
			try
			{
				byte[] data = Encoding.UTF8.GetBytes(message);
				Stream.Write(data, 0, data.Length);
				Stream.Flush();
				Log.Debug($"客户端发送消息: {message}");
			}
			catch (Exception e)
			{
				Log.Debug($"发送失败: {e.Message}");
			}
		}



	}
}

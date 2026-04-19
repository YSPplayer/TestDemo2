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

namespace Assets.Resource.Script.Core.Socket
{
	public class TcpCilent
	{
		private TcpClient Client { get; set; }
		//private int Ip { get; set; } //IP地址
		private int Port { get; set; } //端口号
		private NetworkStream Stream { get; set; }
		public TcpCilent()
		{
			Client = new TcpClient();
			Stream = null;
			//Ip = 127.0.0.1;
			Port = 9093;
		}
		public bool Connect()
		{
			try
			{
				Client.Connect(IPAddress.Any, Port);
				Stream = Client.GetStream();
				Log.Debug("客户端连接成功！");
				return true;
			}
			catch (Exception e)
			{
				Log.Debug($"客户端连接失败: {e.Message}");
				return false;
			}
		}

		/// <summary>
		/// 异步发送消息
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public async Task SendMessageAsync(string message)
		{
			try
			{
				byte[] data = Encoding.UTF8.GetBytes(message);
				await Stream.WriteAsync(data, 0, data.Length);
				await Stream.FlushAsync();
				Console.WriteLine($"发送: {message}");
			}
			catch (Exception e)
			{
				Console.WriteLine($"发送失败: {e.Message}");
			}
		}



	}
}

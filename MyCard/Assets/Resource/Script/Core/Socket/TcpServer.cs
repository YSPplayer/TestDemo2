using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEditor.Experimental.GraphView;

namespace Assets.Resource.Script.Core.Socket
{
	public class TcpServer
	{
		private TcpListener listener;
		private int port;
		public TcpServer() 
		{
			listener = null;
			port = 9093;
		}
		public void Start()
		{
			listener = new TcpListener(IPAddress.Any, port);
			listener.Start();
		}
	}
}

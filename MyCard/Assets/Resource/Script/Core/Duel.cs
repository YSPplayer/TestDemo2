using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using UnityEditor.Search;
using Assets.Resource.Script.Core.Socket;
using Unity.VisualScripting;
using System.Net;
namespace Assets.Resource.Script.Core
{
	public class Duel
	{
		public Phase Phase { get; private set; } //当前的比赛阶段
		public List<Player> Players { get; set; } //玩家
		public GameServer TcpServer { get; set; } //游戏服务器
		public GameMode GameMode { get; set; } //游戏模式
		public int Turn { get; private set; } //当前回合数
		public Action<Player, string> processClientReceive;
		public Duel()
		{
			Phase = Phase.GameStart;
			GameMode = GameMode.PVP_2;
			Players = new List<Player>(2);//2个玩家
			TcpServer = new GameServer();
			processClientReceive = null;
			TcpServer.BindMessageFunc(ProcessClientReceive);
		}
		public void BindMessageFunc(Action<Player, string> processClientReceive) {
			this.processClientReceive = processClientReceive;
		}
		public void ProcessClientReceive(TcpClient tcpClient, string msg)
		{
			Player player = GetPlayer(tcpClient);
			if (player == null)
			{
				Log.Debug($"未寻找到有效的玩家对象");
				return;
			}
			player.IsReceive = true;
			Log.Debug($"服务器接收到客户端消息：{msg}");
			if (processClientReceive != null) processClientReceive(
				player , msg);
		}
		public Player GetPlayer(TcpClient tcpClient)
		{
			if (tcpClient == null) return null;

			// 获取需要匹配的远程终结点（IP 和端口）
			var targetEndpoint = tcpClient.Client.RemoteEndPoint as System.Net.IPEndPoint;
			if (targetEndpoint == null) return null;
			Log.Debug($"对象客户端:{targetEndpoint.Address.ToString()}端口:{targetEndpoint.Port.ToString()}");
			foreach (Player player in Players)
			{
				if (player == null) continue;
				if (player.GameCilent == null) continue;
				int playerport = player.GameCilent.LocalPort;
				string playerip = player.GameCilent.LocalAddress;
				Log.Debug($"匹配客户端:{playerip}端口:{playerport}");
				// 比较 IP 地址和端口号
				if (targetEndpoint.Address.ToString().Equals(playerip) &&
					targetEndpoint.Port == playerport)
				{
					return player;
				}
			}
			return null;
		}
		public bool IsAllReceive()
		{
			foreach (Player player in Players)
			{
				if (player == null) continue;
				if(!player.IsReceive) return false;
			}
			return true;
		}
		public void BroadcastAll(DuelMsg msg)
		{
			foreach (Player player in Players) {
				if (player != null) player.IsReceive = false;
			}
			TcpServer.BroadcastAll(JsonManage.ToString(msg));
		}
		public int PlayerToInt(Player player)
		{
			for (int i = 0; i < Players.Count; ++i)
			{
				if (Players[i] == player) return i;
			}
			return -1;
		}
		public void NextPhase()
		{
			if (Phase == Phase.End || Phase == Phase.GameStart) Phase = Phase.Setup;
			else Phase++;
		}
		public void StartServer() 
		{
			TcpServer.Start();
		}

		public void StopServer()
		{
			TcpServer.Stop();
		}
	}
}

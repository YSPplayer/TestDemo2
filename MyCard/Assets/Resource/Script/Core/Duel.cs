using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEditor.Search;
using Assets.Resource.Script.Core.Socket;
using Unity.VisualScripting;
namespace Assets.Resource.Script.Core
{
	public class Duel
	{
		public Phase Phase { get; private set; } //当前的比赛阶段
		public List<Player> Players { get; set; } //玩家
		public TcpServer TcpServer { get; set; } //游戏服务器
		public GameMode GameMode { get; set; } //游戏模式
		public int Turn { get; private set; } //当前回合数
		public Duel()
		{
			Phase = Phase.GameStart;
			GameMode = GameMode.PVP_2;
			Players = new List<Player>(2);//2个玩家
			TcpServer = new TcpServer();
		}
		public void BroadcastAll(string msg)
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

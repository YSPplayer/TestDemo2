using Assets.Resource.Script.Core.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resource.Script.Core
{
	public class Player
	{
		private static int IdCount = 0;
		private static object obj = new object();
		public int Id { get; set; } //玩家唯一id
		public string Name { get; set; } //玩家名称
		public Deck Deck { get; set; } //玩家卡组
		public List<Card> Hands { get; set; } //玩家手卡

		public List<Card> Grave { get; set; } //弃牌区 

		public bool IsReceive { get; set; } //客户端是否接收到服务器信息

		public GameCilent GameCilent { get; set; }

		public Action<Player, string> processDuel;
		public Player() {
			Name = "";
			Deck = new Deck();
			Hands = new List<Card>();
			Grave = new List<Card>();
			IsReceive = true;
			GameCilent = new GameCilent();
			processDuel = null;
			GameCilent.Connect();
			GameCilent.BindMessageFunc(ProcessDuel);
			lock (obj)
			{
				Id = IdCount;
				++IdCount;
			}
		}
		public void BindMessageFunc(Action<Player, string>  processDuel)
		{
			this.processDuel = processDuel;
		}
		public void SendMessage(ClientMsg message)
		{
			GameCilent.SendMessage(JsonManage.ToString(message));
		}
		public void ProcessDuel(string message)
		{
			if (processDuel != null) processDuel(this, message);
		}
		public int GetDeckCount()
		{
			return Deck.Count();
		}

		public int GetHandCount()
		{
			return Hands.Count();
		}
		public int GetGraveCount()
		{ 
			return Grave.Count();
		}
	}
}

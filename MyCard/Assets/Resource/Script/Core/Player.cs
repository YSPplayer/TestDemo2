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
		public string Name { get; set; } //玩家名称
		public Deck Deck { get; set; } //玩家卡组
		public List<Card> Hands { get; set; } //玩家手卡

		public List<Card> Grave { get; set; } //弃牌区 

		public bool IsReceive { get; set; } //客户端是否接收到服务器信息
	private TcpCilent tcpCilent = null;
		public Player() {
			Name = "";
			Deck = new Deck();
			Hands = new List<Card>();
			Grave = new List<Card>();
			tcpCilent = new TcpCilent();
			//连接客户端
			tcpCilent.Connect();
			IsReceive = true;
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

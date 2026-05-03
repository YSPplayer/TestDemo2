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

		private TcpCilent tcpCilent = null;
		public Player() {
			Name = "";
			Deck = new Deck();
			Hands = new List<Card>();
			tcpCilent = new TcpCilent();
			//连接客户端
			tcpCilent.Connect();
		}
		public int GetDeckCount()
		{
			return Deck.Count();
		}
	}
}

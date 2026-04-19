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
		public List<Card> hands { get; set; } //玩家手卡

		public Player() {
			Name = "";
			Deck = new Deck();
			hands = new List<Card>();
		}
		public int GetDeckCount()
		{
			return Deck.Count();
		}
	}
}

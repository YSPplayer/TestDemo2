using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resource.Script.Core
{
	public class Deck
	{
		public List<Card> Cards { get; set; } //以0索引为顶部牌堆
		private static Random random = new Random();
		public Deck()
		{
			Cards = new List<Card>();
		}
		public Deck(List<Card> cards)
		{
			Cards = cards;
		}
		public int Count()
		{
			return Cards.Count;
		}
		public void Shuffle()
		{
			for (int i = Cards.Count - 1; i > 0; i--)
			{
				int j = random.Next(i + 1);
				Swap(Cards, i, j);
			}
		}
		public List<Card> Draw(int count)
		{
			if (count <= 0) return new List<Card>();
			if (count >= Cards.Count)
			{
				var allCards = new List<Card>(Cards);
				Cards.Clear();
				return allCards;
			}
			var cards = Cards.Take(count).ToList();
			Cards.RemoveRange(0, count);  // 批量移除，性能更好
			return cards;
		}
		private static void Swap(List<Card> deck, int i, int j)
		{
			(deck[j], deck[i]) = (deck[i], deck[j]);
		}
	}
}

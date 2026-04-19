using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resource.Script.Core
{
	public class Deck
	{
		public List<Card> Cards { get; set; }
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
	}
}

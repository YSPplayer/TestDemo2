using Assets.Resource.Script.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resource.Script.Client
{
	/// <summary>
	/// 测试类启动器
	/// </summary>
	public class RunDemo
	{
		private static List<Card> CreateMonsterCard()
		{
			JsManager jsManager = new JsManager();
			jsManager.LoadScript();
			List<Card> cards = jsManager.ExecuteScripts();
			//List<Card> cards = new List<Card>();
			for (int i = 0; i < 30; ++i)
			{
				Card card = new Card(cards[0]);
				cards.Add(card);
			}
			return cards;
		}
		private static Player CreatePlayer()
		{
			Player  player = new Player();
			player.Deck = new Deck(CreateMonsterCard());
			return player;
		}
		public static Duel CreateDuel()
		{ 
			Duel duel = new Duel();
			//每一个角色30张卡组
			Player player0 = CreatePlayer();
			Player player1 = CreatePlayer();
			duel.Players.Add(player0);
			duel.Players.Add(player0);
			return duel;
		}
	}
}

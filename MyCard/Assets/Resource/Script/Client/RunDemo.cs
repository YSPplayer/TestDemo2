using Assets.Resource.Script.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resource.Script.Core.Socket;
using Assets.Resource.Script.Core.Mode;
namespace Assets.Resource.Script.Client
{
	/// <summary>
	/// 测试类启动器
	/// </summary>
	public class RunDemo
	{
		private static JsManager jsManager = new JsManager();
		private static List<Card> jscards = null;
		private static Duel duel = null;
		private static PlayerMode2V2 mode2V2 = null;
		public static Action<Player,string> processDuel
			= null;
		private static List<Card> CreateMonsterCard()
		{
			if (jscards == null)
			{
				jsManager.LoadScript();
				jscards = jsManager.ExecuteScripts();
			}
			List<Card> cards = new List<Card>();
			for (int i = 0; i < 30; ++i)
			{
				Card card = null; 
				if (jscards[0].CardType == CardType.Monster)
				{
					card = new MonsterCard(jscards[0] as MonsterCard);
				}
				else
				{
					card = new Card(jscards[0]);
				}
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
			duel = new Duel();
			mode2V2 = new PlayerMode2V2(duel);
			duel.StartServer();
			//每一个角色30张卡组
			Player player0 = CreatePlayer();
			Player player1 = CreatePlayer();
		    GameCilent client0 = player0.GameCilent;
			if (processDuel != null) {
				player0.BindMessageFunc(processDuel);
				player1.BindMessageFunc(processDuel);
			}
			duel.Players.Add(player0);
			duel.Players.Add(player0);
			return duel;
		}
		public static void Destory()
		{
			duel.StopServer();
		}
	}
}

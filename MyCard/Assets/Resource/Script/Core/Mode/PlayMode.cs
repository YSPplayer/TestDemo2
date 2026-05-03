using Assets.Resource.Script.Core.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
//游戏类型
namespace Assets.Resource.Script.Core.Mode
{
	public class PlayMode
	{
		protected Duel duel;
		public PlayMode(Duel duel)
		{
			this.duel = duel;
			this.duel.TcpServer.BindMessageFunc(ProcessClientReceive);
		}
		protected virtual void ProcessClientReceive(TcpClient cilent, string msg)
		{ 
		
		}
		protected virtual void ProcessDuel()
		{
			
		}
		protected DuelMsg CreateDuelMsg(Phase phase, int player,
			List<Card> cards)
		{
			DuelMsg msg = new DuelMsg();
			msg.p = (int)phase;
			if (phase == Phase.GameStart) {
				msg.ce = (int)GEvent.OnGameStart;
			}
			msg.cp = player;
			msg.codes = new long[cards.Count];
			msg.states = new int[cards.Count][];
			for (int i = 0; i < cards.Count; ++i)
			{
				var card = cards[i];
				msg.codes[i] = card.Code;
				if (card.CardType == CardType.Monster)
				{
					MonsterCard monsterCard = (MonsterCard)card;
					msg.states[i] = new int[5];
					msg.states[i][0] = (int)monsterCard.CardType;//卡片种类
					msg.states[i][1] = monsterCard.Atk;//攻击力
					msg.states[i][2] = monsterCard.Hp;//HP
					msg.states[i][3] = monsterCard.Def;//守备力
					msg.states[i][4] = monsterCard.Shd;//盾牌
				}
				else
				{
					msg.states[i] = new int[1];
					msg.states[i][0] = (int)card.CardType;//卡片种类
				}
				
			}
			return msg;
		}
	}
}

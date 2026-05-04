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
			this.duel.BindMessageFunc(ProcessClientReceive);
		}
		protected virtual void ProcessClientReceive(Player palyer, string msg)
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
			msg.turn = duel.Turn;
			msg.codes = new long[cards.Count];
			msg.states = new CardState[cards.Count];
			for (int i = 0; i < cards.Count; ++i)
			{
				var card = cards[i];
				msg.codes[i] = card.Code;
				CardState state = new CardState();
				state.type = (int)card.CardType;//卡片种类
				if (card.CardType == CardType.Monster)
				{
					MonsterCard monsterCard = card as MonsterCard;
					state.atk = monsterCard.Atk;//攻击力
					state.hp = monsterCard.Hp;//HP
					state.def = monsterCard.Def;//守备力
					state.shd = monsterCard.Shd;//盾牌

				}
				msg.states[i] = state;
			}
			return msg;
		}
	}
}

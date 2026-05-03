using Assets.Resource.Script.Core.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.XR;

namespace Assets.Resource.Script.Core.Mode
{
	public class PlayerMode2V2 :PlayMode
	{
		public PlayerMode2V2(Duel duel) : base(duel)
		{
	
		}
		protected override void ProcessClientReceive(TcpClient cilent, string msg)
		{
			DuelMsg duelMsg = JsonManage.ToObj<DuelMsg>(msg);
		}
		//决斗过程
		protected override void ProcessDuel()
		{
			Phase phase = duel.Phase;
			Player player0 = duel.Players[0];
			Player player1 = duel.Players[1];
			Deck deck0 = player0.Deck;
			Deck deck1 = player1.Deck;
			var hands0 = player0.Hands;
			var hands1 = player1.Hands;
			var garve0 = player0.Grave;
			var garve1 = player1.Grave;
			if (phase == Phase.GameStart) //游戏开始阶段，双方要分别初始化4张手卡
			{
				//先洗牌
				deck0.Shuffle();
				deck1.Shuffle();
				//先给玩家A发牌，等待玩家A准备完毕之后再给玩家B发牌
				List<Card> deckcards = deck0.GetTopCards(4);
				DuelMsg msg = CreateDuelMsg(phase, duel.PlayerToInt(player0), deckcards);
				//初始化4张手卡
				duel.BroadcastAll(JsonManage.ToString(msg));
			}
		}
	}
}

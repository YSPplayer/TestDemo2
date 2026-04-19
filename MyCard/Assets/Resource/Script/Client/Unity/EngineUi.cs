using Assets.Resource.Script.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resource.Script.Client.Unity
{
	
	public class EngineUi:MonoBehaviour
	{
		public Text player0DeckCount;//玩家0的卡组卡片数量
		public Text player1DeckCount;//玩家1的卡组卡片数量

		private Duel duel;
		private void Awake()
		{
			duel = RunDemo.CreateDuel();
		}
		/// <summary>
		/// 绘制帧
		/// </summary>
		public void Draw()
		{
			Player player0 = duel.Players[0];
			Player player1 = duel.Players[1];
			Log.Debug(player0DeckCount);
			Log.Debug(player1DeckCount);
			player0DeckCount.text = player0.GetDeckCount().ToString();
			player1DeckCount.text = player1.GetDeckCount().ToString();
		}
	}
}

using UnityEngine;
/*
  事件：上场时，受到伤害时
阶段：准备，抽卡，主要(登场),结束
 */
namespace Assets.Resource.Script.Core
{
	public enum Phase
	{
		GameStart,//游戏开始阶段
		Setup,//备战准备
		Draw,//备战抽卡
		Main,//备战主要阶段
		End, //备战结束阶段
		GameEnd //游戏结束阶段
	}
	public enum CardType
	{
		Monster,//怪兽卡
	}
	public enum EndReason
	{ 
		ReasonDeckNull,//牌组为空失败
	}
	public enum GEvent
	{
		OnGameStart,//游戏开始时
		OnStage,//登场时
		OnDraw,//抽卡时
	}
	public enum GameMode
	{ 
		PVP_2,//双人决斗模式
	}

	//交互信息
	[System.Serializable]
	public class DuelMsg
	{
		public int p;//阶段
		public int ce;//当前触发的事件
		public int cp;//当前触发的玩家
		public long[] codes;//卡号
		public int[][] states;//卡状态
	}
}

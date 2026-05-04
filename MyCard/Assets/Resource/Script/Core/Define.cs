using System.Collections.Generic;
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
	public enum ClientCode
	{ 
		OK = 200,
		Error = 400
	}
	public enum ClientType
	{
		GameStart = 1,//开始游戏
		GameStartOverHand = 2,//游戏开始，已准备初始手卡
	}
	//服务器消息
	[System.Serializable]
	public class ClientMsg
	{
		public int type;//当前的类型
		public int state;//当前状态
	}
	[System.Serializable]
	public class CardState
	{
		public int type;
		public int atk;
		public int hp;
		public int def;
		public int shd;
	}
	//交互信息
	[System.Serializable]
	public class DuelMsg
	{
		public int p;//阶段
		public int turn;//回合数
		public int ce;//当前触发的事件
		public int cp;//当前触发的玩家
		public long[] codes;//卡号
		public CardState[] states;//卡状态
	}
}

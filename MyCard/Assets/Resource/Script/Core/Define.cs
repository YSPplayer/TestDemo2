using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
  事件：上场时，受到伤害时
阶段：准备，抽卡，主要(登场),结束
 */
namespace Assets.Resource.Script.Core
{
	public enum Phase
	{
		GameStart,//游戏开始阶段
		Setup,//准备
		Draw,//抽卡
		Main,//主要
		End, //结束
		GameEnd //游戏结束阶段
	}
	public enum CardType
	{
		Monster,//怪兽卡
	}
	public enum GEvent
	{
		OnStage,//登场时
		OnDraw,//抽卡时
	}
}

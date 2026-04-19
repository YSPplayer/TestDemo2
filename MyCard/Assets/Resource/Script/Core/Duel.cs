using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEditor.Search;
namespace Assets.Resource.Script.Core
{
	public class Duel
	{
		private Phase Phase { get; set; } //当前的比赛阶段
		public List<Player> Players { get; set; } //玩家
		public Duel()
		{
			Phase = Phase.GameStart;
			Players = new List<Player>(2);//2个玩家
		}
	}
}

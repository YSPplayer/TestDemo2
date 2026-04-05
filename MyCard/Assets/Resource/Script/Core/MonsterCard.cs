
namespace Assets.Resource.Script.Core
{
	public class MonsterCard : Card
	{
		public int HP { get; set; } // 生命力
		public int Attack { get; set; } // 攻击力
		public int Defense { get; set; } // 守备力
		public int Shield { get; set; } // 护盾值

		public MonsterCard(long code, string name, string description, int hp, int attack, int defense, int shield)
			: base(code, name, description)
		{
			HP = hp;
			Attack = attack;
			Defense = defense;
			Shield = shield;
		}
	}
}

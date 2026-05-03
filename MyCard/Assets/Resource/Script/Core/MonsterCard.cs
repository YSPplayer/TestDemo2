
namespace Assets.Resource.Script.Core
{
	public class MonsterCard : Card
	{
		public int Atk { get; set; } //攻击力
		public int Hp { get; set; } //生命值
		public int Def { get; set; } //防御力
		public int Shd { get; set; } //护盾

		public MonsterCard(long code, string name, string description,CardType cardType, int atk, int hp, int def,int shd)
			: base(code, name, description, cardType)
		{
			Atk = atk;
			Hp = hp;
			Def = def;
			Shd = shd;
		}

		// 拷贝构造函数
		public MonsterCard(MonsterCard other)
			: base(other.Code, other.Name, other.Description, other.CardType)
		{
			Atk = other.Atk;
			Hp = other.Hp;
			Def = other.Def;
			Shd = other.Shd;
		}
	}
}

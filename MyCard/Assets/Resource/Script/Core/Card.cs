namespace Assets.Resource.Script.Core
{
	public class Card
	{
		public long Code { get; set; } // 卡牌编号
		public string Name { get; set; } // 卡牌名称

		public CardType CardType { get; set; } //卡片类型
		public string Description { get; set; } // 卡牌描述

		public Card(long code, string name, string description, CardType cardType)
		{
			Code = code;
			Name = name;
			Description = description;
			CardType = cardType;

		}
	}
}

using Assets.Resource.Script.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Assets.Resource.Script.Client.Unity
{
	
	public class EngineUi:MonoBehaviour
	{
		public static readonly Queue<Action> executionQueue = new Queue<Action>();
		public GameObject cardPrefab;  // 拖拽预制体到这里
		public GameObject handcanvas2;
		public Transform hGroup2;
		public Text player0DeckCount;//玩家0的卡组卡片数量
		public Text player1DeckCount;//玩家1的卡组卡片数量
		public Text currentPlayer;//当前谁处于玩家方 
		public Text turn;//回合数
		public Text phase;//当前阶段
		private Duel duel;
		private void Awake()
		{
			hGroup2 = handcanvas2.transform.GetComponent<HorizontalLayoutGroup>().transform;
			RunDemo.processDuel = ProcessDuel;
			duel = RunDemo.CreateDuel();
		}

		public void Destory()
		{
			RunDemo.Destory();
		}
		public string PhaseToString(Phase phase)
		{
			switch (phase)
			{
				case Phase.GameStart:
					return "游戏开始阶段";
				case Phase.Setup:
					break;
				case Phase.Draw:
					break;
				case Phase.Main:
					break;
				case Phase.End:
					break;
				case Phase.GameEnd:
					break;
				default:
					break;
			}
			return "";
		}
		private void CreateCardText(GameObject obj ,string key, string value)
		{
			Transform tDesc = obj.transform.Find(key);
			if (tDesc != null)
			{
				Text desc = tDesc.GetComponent<Text>();
				desc.text = value;
			}
		}

		//开始游戏
		public void StartGame()
		{
			Player player0 = duel.Players[0];
			Player player1 = duel.Players[1];
			player0.SendMessage(CreateClientMsg(ClientType.GameStart, ClientCode.OK));
			player1.SendMessage(CreateClientMsg(ClientType.GameStart, ClientCode.OK));
		}
		public GameObject CreateCard(long code, CardState state)
		{
			Card card = Card.Datas[code];
			int cardtype = state.type;//卡片种类
			int atk = state.atk;//攻击力
			int hp = state.hp;//攻击力
			int def = state.def;//守备力
			int shd = state.shd;//盾牌
			GameObject cardObj = Instantiate(cardPrefab);//卡片对象
			CreateCardText(cardObj, "Desc", card.Description);
			CreateCardText(cardObj, "Title", card.Name);
			if (cardtype == (int)CardType.Monster)
			{
				CreateCardText(cardObj, "HP", hp.ToString());
				CreateCardText(cardObj, "ATK", atk.ToString());
				CreateCardText(cardObj, "DEF", def.ToString());
				CreateCardText(cardObj, "Shd", shd.ToString());
			}

			return cardObj;
		}
		private void PushAction(Action action)
		{
			lock (executionQueue) 
			{
				executionQueue.Enqueue(action);
			}
		}
		public void ProcessDuel(Player player, string message)
		{
			Log.Debug($"客户端接收到服务器消息:{message}");
			DuelMsg msg = JsonManage.ToObj<DuelMsg>(message);
			bool currentTurn = msg.cp == player.Id; //当前回合
			if (msg.p == (int)Phase.GameStart)
			{  //游戏开始阶段
				if (currentTurn) {  //初始化手卡
					PushAction(() => {
						currentPlayer.text = currentTurn ? "我方回合" : "对方回合";
						turn.text = msg.turn.ToString();
						phase.text = PhaseToString((Phase)msg.p);
						for (int i = 0; i < msg.codes.Count(); ++i)
						{
							GameObject objectCard = CreateCard(msg.codes[i], msg.states[i]);

							// 获取卡片自身的 RectTransform
							RectTransform cardRect = objectCard.GetComponent<RectTransform>();

							// 方法1：根据父容器高度等比例缩放（推荐）
							// 获取卡片原始宽高比
							float originalWidth = cardRect.rect.width;
							float originalHeight = cardRect.rect.height;
							float aspectRatio = originalWidth / originalHeight;
							RectTransform hGroup2Rect = hGroup2.GetComponent<RectTransform>();
							// 设置卡片高度为父容器高度，宽度按比例计算
							float newHeight = hGroup2Rect.rect.height;
							float newWidth = newHeight * aspectRatio;
							cardRect.sizeDelta = new Vector2(newWidth, newHeight);
							// 设置父物体
							objectCard.transform.SetParent(hGroup2, false);
						}
					});
				}
				
				//player.SendMessage(CreateClientMsg(ClientType.GameStartOverHand,ClientCode.OK));
			}
		}
		public ClientMsg CreateClientMsg(ClientType type,ClientCode code)
		{
			ClientMsg msg = new ClientMsg();
			msg.state = (int)code;
			msg.type = (int)type;
			return msg;
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

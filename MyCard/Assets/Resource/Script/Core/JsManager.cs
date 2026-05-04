using Jint;
using Jint.Native.Object;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Resource.Script.Core
{
	public class JsManager
	{
		private Engine jsEngine;
		private Dictionary<string, string> scriptsMap;
		public JsManager()
		{
			jsEngine = new Engine();
			scriptsMap = new Dictionary<string, string>();
			SetEnvFunction();
		}
		//注入js脚本函数
		public void SetEnvFunction()
		{
			jsEngine.SetValue("_loadScript", new Action<string>(scriptName =>
			{
				string fullPath = Path.Combine(Application.dataPath, "Resource/CardScript", scriptName);
				if (File.Exists(fullPath))
				{
					string code = File.ReadAllText(fullPath);
					jsEngine.Execute(code);
					Log.Debug($"加载成功：{scriptName}");
				}
			}));
			jsEngine.SetValue("console", new
			{
				log = new Action<object>(Log.Debug)
			});
		}
		public List<Card> ExecuteScripts()
		{
			ExecuteScript("env");
			List<Card> cards = new List<Card>();
			foreach (var name in scriptsMap.Keys)
			{
				Card card = ExecuteScriptWithCard(name);
				if (card != null) {
					cards.Add(card);
					Card.Datas[card.Code] = card;
				} 
				
			}
			return cards;
		}
		public void LoadScript() 
		{
			//TextAsset[] scripts = Resources.LoadAll<TextAsset>("CardScript");
			string[] scriptPaths = Directory.GetFiles(Application.dataPath + "/Resource/CardScript", "*.js");
			foreach (var scriptPath in scriptPaths)
			{
				// 从文件路径获取文件名（不含扩展名）
				string scriptName = Path.GetFileNameWithoutExtension(scriptPath);
				// 读取文件内容
				string scriptContent = File.ReadAllText(scriptPath);
				scriptsMap[scriptName] = scriptContent;
				Log.Debug($"加载脚本: {scriptName}");
			}
		}
		public Card ToCard(ObjectInstance obj)
		{
			CardType type = (CardType)(obj["type"]?.AsNumber() ?? 0);
			long code = (long)(obj["code"]?.AsNumber() ?? 0);
			string name = obj["name"]?.AsString() ?? "";
			string description = obj["description"]?.AsString() ?? "";
			if (type == CardType.Monster) 
			{
				int atk = (int)(obj["atk"]?.AsNumber() ?? 0);
				int hp = (int)(obj["hp"]?.AsNumber() ?? 0);
				int def = (int)(obj["def"]?.AsNumber() ?? 0);
				int shd = (int)(obj["shd"]?.AsNumber() ?? 0);
				return new MonsterCard(code, name, description, type,
					atk, hp, def, shd);
			}
			return new Card(code,name,description,type);
		}
		public void ExecuteScript(string scriptName)
		{
			if (scriptsMap.ContainsKey(scriptName))
			{
				jsEngine.Execute(scriptsMap[scriptName]);
			}
		}
		public Card ExecuteScriptWithCard(string scriptName)
		{
			long code = Util.ConvertToNumber(scriptName);
			if (code == 0) return null;
			if (scriptsMap.ContainsKey(scriptName))
			{
				jsEngine.Execute(scriptsMap[scriptName]);

				if (jsEngine.Evaluate($"typeof initCard !== 'undefined'").AsBoolean())
				{
					var args = new
					{
						code
					};
					jsEngine.SetValue("args", args);
					var result = jsEngine.Invoke("initCard", args);
					if (result.IsObject()) 
						return ToCard(result.AsObject());
				}
			}
			return null;
		}
	}
}


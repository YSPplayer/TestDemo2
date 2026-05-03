using System;
using UnityEngine;

namespace Assets.Resource.Script.Core
{
	public class JsonManage
	{
		public static string ToString<T>(T obj)
		{ 
			return JsonUtility.ToJson(obj);
		}
		public static T ToObj<T>(string json) 
		{
			return JsonUtility.FromJson<T>(json); 
		}
		
	}
}

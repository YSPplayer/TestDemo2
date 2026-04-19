using System;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resource.Script.Core
{
	public class Log
	{
		public Log() { }
		public static void Debug<T>(T message)
		{ 
			Console.WriteLine(message);
			UnityEngine.Debug.Log(message);
		}
	}
}

using Assets.Resource.Script.Client;
using Assets.Resource.Script.Client.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Main : MonoBehaviour
{
	EngineUi engineUi;
	void Awake()
	{
		engineUi = GetComponent<EngineUi>();
	}

	void Start()
    {
		engineUi.StartGame();

	}
	void OnApplicationQuit()
	{
		engineUi.Destory();

	}

	void Update()
    {
		Queue<Action> queue = EngineUi.executionQueue;
		lock (queue)
		{
			while (queue.Count > 0)
			{
				Action action = queue.Dequeue();
				try
				{
					action?.Invoke();
				}
				catch (Exception ex)
				{
					Debug.LogError("Ö¡º¯ÊýäÖÈ¾´íÎó£º" + ex);
				}
		
			}
		}

	}
}

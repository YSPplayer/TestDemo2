using Assets.Resource.Script.Client;
using Assets.Resource.Script.Client.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
	EngineUi engineUi;
	void Awake()
	{
		engineUi = GetComponent<EngineUi>();
	}

	void Start()
    {
        
    }
	void OnApplicationQuit()
	{ 

	}

	void Update()
    {
		engineUi.Draw();

	}
}

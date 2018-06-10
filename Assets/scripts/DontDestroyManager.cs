using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyManager : SingletonMonoBehaviourFast<DontDestroyManager> {

	public bool isStartGame = false;

	void Awake(){
		DontDestroyOnLoad (this);
	}
}

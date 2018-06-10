using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeController : MonoBehaviour {

	bool isPullPin = false;
	[SerializeField]
	GameObject exprosivePrefab;

	public void PullPin(){
		if(!isPullPin){
			isPullPin = true;
			Invoke ("Exprosive", 5);
		}

	}

	void Exprosive(){
		Instantiate (exprosivePrefab, this.transform.position, Quaternion.identity);
		Debug.Log ("BAN!!!!!!");
		Destroy (this.gameObject);
	}
}

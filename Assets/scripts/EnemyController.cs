using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	GameObject ResultUI;
	[SerializeField]
	GameObject GameUI;

	[SerializeField]
	GameObject MainPcController;

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Exprosive")
		{
			Debug.Log ("game set");
			ShowResultUI();
			Destroy(this.gameObject);
		}
	}

	void ShowResultUI(){
		MainPcController.GetComponent<MainPcController> ().isGameOver = true;
		ResultUI.SetActive (true);
		GameUI.SetActive (false);
	}
}

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
	[SerializeField]
	Animator anim;

	Vector3 granadePosition;
	bool isGranadeAway = false;

	void Awake ()
	{
		anim.SetFloat ("Speed", 1f);
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Exprosive")
		{
			Debug.Log ("game set");
			ShowResultUI();
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "ExprosiveArea"){
			Debug.Log ("do escape");
			granadePosition = col.gameObject.transform.position;
			Invoke ("Escape", 1.2f);
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "ExprosiveArea"){
			isGranadeAway = true;
		}
	}

	void ShowResultUI(){
		MainPcController.GetComponent<MainPcController> ().isGameOver = true;
		ResultUI.SetActive (true);
		GameUI.SetActive (false);
	}

	void Escape(){
		if (!isGranadeAway) {
			Debug.Log ("escape!!!");
			anim.SetBool ("run", true);

			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 130, transform.eulerAngles.z);

			Hashtable parameters = new Hashtable ();
			parameters.Add ("x", -14);
			parameters.Add ("islocal", true);
			parameters.Add ("easeType", iTween.EaseType.linear);
			parameters.Add ("time", 1.5f);
			parameters.Add ("oncomplete", "MoveFinish");
			parameters.Add ("oncompletetarget", this.gameObject);
			iTween.MoveBy (this.gameObject, parameters);
		} else {
			Debug.Log ("cansel escape");
		}
	}

	void MoveFinish(){
		anim.SetBool ("run", false);
	}
}

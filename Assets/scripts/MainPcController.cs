using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MainPcController : MonoBehaviour {

	[SerializeField]
	Animator anim;
	[SerializeField]
	GameObject granadePrefab;
	[SerializeField]
	GameObject granadePosition;
	[SerializeField]
	GameObject camera;
	[SerializeField]
	GameObject aim;
	[SerializeField]
	GameObject Enemy;
	[SerializeField]
	FirstPersonController FirstPersonController;

	//UI
	[SerializeField]
	GameObject uiPinText;
	[SerializeField]
	Text loseMessage;
	[SerializeField]
	Text loseRank;
	[SerializeField]
	Text loseKill;
	[SerializeField]
	GameObject resultUI;
	[SerializeField]
	GameObject gameUI;
	[SerializeField]
	GameObject startUI;


	float speed = 1200;
	bool isThrowStandby = false;
	int granadeCount = 1;

	private GameObject instantiatedGranade;
	private Rigidbody instantiatedGranadeRigidbody;

	public bool isGameOver = false;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			anim.SetBool ("isThrow", true);
			Invoke ("ChangeIsThrowStandbyFlag", 1);
			aim.SetActive (true);
		}
		if(!Input.GetButton("Fire1") && isThrowStandby){
			Debug.Log ("throw!!");
			aim.SetActive (false);
			if(instantiatedGranade == null){
				isThrowStandby = false;
				return;
			}

			instantiatedGranade.GetComponent<GranadeController> ().PullPin ();
			Invoke ("CheckGameOver", 8);
			isThrowStandby = false;
			Vector3 throwVecter =granadePosition.transform.forward * speed;
			instantiatedGranade.transform.parent = null;
			instantiatedGranadeRigidbody.isKinematic = false;
			instantiatedGranadeRigidbody.AddForce(throwVecter);
			granadeCount--;
		}
		if(Input.GetKeyDown("r") && isThrowStandby){
			Debug.Log ("pull pin");
			instantiatedGranade.GetComponent<GranadeController> ().PullPin ();

			uiPinText.SetActive (true);
			Invoke ("ActiveFalsePinUI", 1);
			Invoke ("CheckGameOver", 8);
		}

		if(Input.GetKeyDown("b")){
			ReloadScene ();
		}
	}

	void ChangeIsThrowStandbyFlag(){
		if(granadeCount > 0){
			Debug.Log ("throw Standby");
			isThrowStandby = true;
			instantiatedGranade = Instantiate (granadePrefab, granadePosition.transform.position, Quaternion.identity);
			instantiatedGranade.transform.SetParent (granadePosition.transform);
			instantiatedGranadeRigidbody = instantiatedGranade.GetComponent<Rigidbody> ();
			instantiatedGranadeRigidbody.isKinematic = true;
		}
	}

	void ActiveFalsePinUI(){
		uiPinText.SetActive (false);
	}

	void CheckGameOver(){
		if(Enemy != null){
			loseMessage.text = "こんな日もあるさ！強く生きよう！";
			loseRank.text = "#2";
			loseKill.text = "キル 0";
			resultUI.SetActive (true);
			gameUI.SetActive (false);

			isGameOver = true;
		}
	}

	public void ReloadScene(){
		if(isGameOver){
			isGameOver = false;
			Debug.Log ("ReloadScene");
			Scene loadScene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (loadScene.name);
		}
	}

	public void OnClickStart(){
		startUI.SetActive (false);
		FirstPersonController.enabled = true;
	}
}

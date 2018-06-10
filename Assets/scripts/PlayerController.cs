using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed = 10.0f;
	public int laneNum = 1;
	int maxLaneNum = 2;
	public bool isMoving = false;

	
	// Update is called once per frame
	void Update () {
        MoveFoward();
	}

    private void MoveFoward (){
        transform.position += transform.forward * Time.deltaTime * MoveSpeed;
    }



    public void MoveLeft (){
		if((laneNum-1) >= 0 && !isMoving){
			isMoving = true; 
			laneNum--;

			Hashtable parameters = new Hashtable();
			parameters.Add("x", -2);
			parameters.Add("islocal", true);
			parameters.Add("easeType",iTween.EaseType.linear);
			parameters.Add("time", 0.3f);
			parameters.Add("oncomplete", "MoveFinish");
			parameters.Add("oncompletetarget", this.gameObject);
			iTween.MoveBy(this.gameObject, parameters);
		}
    }

    public void MoveRight (){
		if ((laneNum + 1) <= maxLaneNum && !isMoving) {
			isMoving = true;
			laneNum++;

			Hashtable parameters = new Hashtable();
			parameters.Add("x", 2);
			parameters.Add("islocal", true);
			parameters.Add("easeType",iTween.EaseType.linear);
			parameters.Add("time", 0.3f);
			parameters.Add("oncomplete", "MoveFinish");
			parameters.Add("oncompletetarget", this.gameObject);
			iTween.MoveBy(this.gameObject, parameters);
		}
    }

    public void Jump (){
        iTween.MoveBy(this.gameObject, iTween.Hash(
            "y",3,
            "easeType",iTween.EaseType.linear,
            "time",0.25f
        ));
    }

	public void MoveFinish(){
		isMoving = false;
	}
}

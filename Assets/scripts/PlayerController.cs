using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MoveFoward();
	}

    private void MoveFoward (){
        transform.position += transform.forward * Time.deltaTime * MoveSpeed;
    }

    public void MoveLeft (){
        iTween.MoveBy(this.gameObject, iTween.Hash(
            "x",-3,
            "easeType",iTween.EaseType.linear,
            "time",0.1f
        ));
    }

    public void MoveRight (){
        iTween.MoveBy(this.gameObject, iTween.Hash(
            "x",3,
            "easeType",iTween.EaseType.linear,
            "time",0.1f
        ));
    }

    public void Jump (){
        iTween.MoveBy(this.gameObject, iTween.Hash(
            "y",3,
            "easeType",iTween.EaseType.linear,
            "time",0.25f
        ));
    }

        
}

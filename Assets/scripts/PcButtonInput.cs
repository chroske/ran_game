using UnityEngine;
using System.Collections;

public class PcButtonInput : MonoBehaviour {

    public GameObject player;

    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow)) {
            playerController.MoveRight();
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            playerController.MoveLeft();
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            playerController.Jump();
        }

        if (Input.GetKey(KeyCode.DownArrow)) {

        }
	}
}

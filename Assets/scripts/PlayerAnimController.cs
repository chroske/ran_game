using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour {

	private Animator anim; 


	void Awake ()
	{
		anim = GetComponent<Animator> ();
		anim.SetFloat ("Speed", 1f);
	}
}

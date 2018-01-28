using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectsides : MonoBehaviour {

	public PlayerController pc;

	// Use this for initialization
	void OnCollisionStay () {
		pc.canmoveH = false;
	}
	
	// Update is called once per frame
	void OnCollisionExit () {
		pc.canmoveH = true;
	}
}

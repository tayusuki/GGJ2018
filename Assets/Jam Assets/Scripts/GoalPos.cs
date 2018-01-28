using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPos : MonoBehaviour {

	public float holdAmount = 5f;
	public float holdtimer = 0f;

	// Use this for initialization
	void Start () {
		holdtimer = holdAmount;
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider hit) {
		if (hit.transform.tag == "Sign") {
			Debug.Log ("ayyy");
			holdtimer -= 0.1f;
		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.transform.tag == "Sign") {
			holdtimer = holdAmount;
		}
	}
}

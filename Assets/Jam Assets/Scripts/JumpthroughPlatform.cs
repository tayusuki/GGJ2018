using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpthroughPlatform : MonoBehaviour {
	private PlayerController pc;
	private Collider col;
	private bool fallingthru = false;

	void Awake() {
		pc = FindObjectOfType<PlayerController> ();	
		col = GetComponent<Collider> ();
		col.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (pc.transform.position.y - 1.7f > transform.position.y && !fallingthru) {
			col.enabled = true;
		} else if (col.enabled == true){
			col.enabled = false;
		}
	}

	public void DisablePlat(){
		pc.transform.position += Vector3.down * 0.75f;
		col.enabled = false;
	}
}

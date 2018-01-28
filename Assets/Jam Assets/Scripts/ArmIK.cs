using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmIK : MonoBehaviour {

	public GameObject armTarget;
	public GameObject arm1;
	public GameObject arm2;

	private PlayerController pc;

	// Use this for initialization
	void Start () {
		pc = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targpos = (transform.position + Vector3.up) + (Camera.main.ScreenToWorldPoint (Input.mousePosition) - (transform.position + Vector3.up)).normalized * 2.5f;
		targpos.z = transform.position.z;
		armTarget.transform.position = targpos;
		armTarget.transform.LookAt(this.transform.position);

		arm1.transform.right = (-transform.localScale.x *(armTarget.transform.position - arm1.transform.position).normalized);
		arm2.transform.right = (-transform.localScale.x *(armTarget.transform.position - arm2.transform.position).normalized);
		//arm1.transform.forward = Vector3.Cross(-(armTarget.transform.position - arm1.transform.position).normalized, arm1.transform.up);
		//Debug.Log (-(armTarget.transform.position - arm1.transform.position).normalized);
		//arm1.transform.rotation = Quaternion.Inverse (arm1.transform.rotation);
	}
}

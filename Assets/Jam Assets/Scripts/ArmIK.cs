using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmIK : MonoBehaviour {

	public GameObject armTarget;
	public GameObject arm1;
	public GameObject arm2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		arm1.transform.right = -(armTarget.transform.position - arm1.transform.position).normalized;
		//arm1.transform.rotation = Quaternion.Inverse (arm1.transform.rotation);
	}
}

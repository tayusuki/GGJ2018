﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPos : MonoBehaviour {

	public float holdAmount = 5f;
	public float holdtimer = 0f;

	private GameManager gm;
    internal bool hasTransitioned = false;

	// Use this for initialization
	void Awake() {
		holdtimer = holdAmount;
		gm = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider hit) {
		if (hit.transform.tag == "Sign") {
			if (holdtimer > 0) {
				holdtimer -= 0.1f;
			} else {
                if (!hasTransitioned)
                {
                    gm.WinRoundFunc();
                    hasTransitioned = true;
                }
			}
		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.transform.tag == "Sign") {
			holdtimer = holdAmount;
		}
	}
}

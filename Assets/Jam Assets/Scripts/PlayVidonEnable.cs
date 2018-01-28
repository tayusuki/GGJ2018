using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVidonEnable : MonoBehaviour {

	private VideoPlayer playa;

	void Awake(){
		playa = GetComponent<VideoPlayer> ();
	}
	// Use this for initialization
	void OnEnable() {
		playa.Play ();
	}
}

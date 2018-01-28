using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour {

    string[] headlines = new string[5];

    public Text textbox;

	void Start () {
        textbox.text = headlines[Random.Range(0, headlines.Length - 1)];
	}
	
	void Update () {
		
	}
}

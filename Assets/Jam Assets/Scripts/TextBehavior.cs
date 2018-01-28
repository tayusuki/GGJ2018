using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour {

    string[] headlines = new string[5];
    public Image[] icons = new Image[7];
    public Text[] DOW = new Text[7];
    public Text[] description = new Text[7];
    public Text[] high = new Text[7];
    public Text[] low = new Text[7];

    public Text headline;

	void Start () {
        headline.text = headlines[Random.Range(0, headlines.Length - 1)];
	}
	
	void Update () {
		
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int roundNumber = 1;
	public int health = 3;
	public int timer = 20;

	private AudioSource snd;
	public Text healthText;
	public Text timertext;
	Coroutine timerinstance;

	public PlayerController pc;
	public Animator CanvasAnim;
	public Text DayNumber;
	public AudioClip newsSnd;
	public Text AnnouncmentText;
	public string[] Announcments;
	public Text CongratsText;
	public string[] Congrats;
	public Text InsultText;
	public string[] Insults;


    public InitializeGame gameInitializer;
    public Image image1;
    public Image image2;
    public Text text1;
    public Text text2;
    public Text viewers;
    int score = 0;

	public GameObject firstGObutton;

	void Start () {
		snd = GetComponent<AudioSource> ();
		timertext.text = timer.ToString();
		pc.canControl = false;
		CanvasAnim = GetComponent<Animator> ();

		StartCoroutine (StartRound ());
	}
    /*
	void Update(){
		if (Input.GetKeyDown (KeyCode.C)) {
			StartCoroutine (WinRound ());
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			StartCoroutine (GameOver());
		}
	}
    */
	IEnumerator StartRound () {
		CanvasAnim.SetTrigger ("Intro");
        gameInitializer.Initialize();
        AnnouncmentText.text = Announcments [Random.Range (0, Announcments.Length)];
		DayNumber.text = "Day " + roundNumber.ToString ();
		yield return new WaitForSeconds (1f);
		snd.clip = newsSnd;
		snd.Play ();
		yield return new WaitForSeconds (2f);
		if (roundNumber < 5) {
			timer = 20;
		} else if (roundNumber < 10) {
			timer = 10;
		} else if (roundNumber < 15) {
			timer = 5;
		}
		timertext.text = timer.ToString();

		if (health == 3) {
			healthText.text = " ";
		} else if (health == 2) {
			healthText.text = "X";
		} else if (health == 1) {
			healthText.text = "X X";
		}
		yield return new WaitForSeconds (1f);
		timerinstance = StartCoroutine(TickTimer ());
		pc.canControl = true;
		//yield return new WaitForSeconds (1f);
	}

	IEnumerator WinRound (){
		StopCoroutine(timerinstance);
		roundNumber += 1;
        score += Random.Range(10, 51);
		CanvasAnim.SetTrigger ("WinRound");
		CongratsText.text = Congrats [Random.Range (0, Congrats.Length)];
        pc.canControl = false;
        viewers.text = "Viewers: " + score;
		yield return new WaitForSeconds (3f);
		StartCoroutine (StartRound ());
	}

	public void WinRoundFunc(){
		StartCoroutine (WinRound ());
	}

	IEnumerator LoseRound (){
		pc.canControl = false;
		if (health > 1) {
			roundNumber += 1;
			health -= 1;
			CanvasAnim.SetTrigger ("LoseRound");
			InsultText.text = Insults [Random.Range (0, Insults.Length)];
			yield return new WaitForSeconds (3f);
			StartCoroutine (StartRound ());
		} else {
			StartCoroutine (GameOver ());
		}
	}

	IEnumerator GameOver (){
		pc.canControl = false;
		CanvasAnim.SetTrigger ("GameOver");
		EventSystem.current.SetSelectedGameObject (firstGObutton);
		yield return new WaitForSeconds (8f);
		Cursor.visible = true;
	}

	IEnumerator TickTimer(){
		yield return new WaitForSeconds (1f);
		if (timer > 0) {
			timer -= 1;
			timertext.text = timer.ToString();
			timerinstance = StartCoroutine (TickTimer ());
		} else {
			StartCoroutine (LoseRound ());
		}
	}


	public void SetSign(Sprite toSet){
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(true);

        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);

        image1.sprite = toSet;
        image2.sprite = toSet;
	}

    public void SetSign(string toSet)
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);

        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);

        text1.text = toSet;
        text2.text = toSet;
    }

    public void ClickRetry(){
		SceneManager.LoadScene (0);
	}
}

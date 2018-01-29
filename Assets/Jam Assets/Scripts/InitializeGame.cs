using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeGame : MonoBehaviour {

    public string[] headlines;
    string[] days = new string[] { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };
    string[] desc = new string[] { "Sunny", "Partly Cloudy", "Cloudy", "Rainy"};
    bool setWrong = false;
    int choice = 0;
    internal Sprite originalIcon;
    internal string originalText;
    int index;

    public Image[] icons = new Image[7];
    public Text[] DOW = new Text[7];
    public Text[] description = new Text[7];
    public Text[] high = new Text[7];
    public Text[] low = new Text[7];

    public Text headline;
    public Sprite[] iconChoices = new Sprite[4];
    public GameObject goal;

	void Start () {

        //Initialize();
	}

    internal void Initialize()
    {
        setWrong = false;
        originalIcon = null;
        originalText = null;
        headline.text = headlines[Random.Range(0, headlines.Length)];

        DOW[0].text = "SUN";
        DOW[1].text = "MON";
        DOW[2].text = "TUE";
        DOW[3].text = "WED";
        DOW[4].text = "THU";
        DOW[5].text = "FRI";
        DOW[6].text = "SAT";

        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].sprite = iconChoices[Random.Range(0, iconChoices.Length)];

            if(icons[i].sprite.name == "Sun")
            {
                description[i].text = "Sunny";
                high[i].text = Random.Range(90, 110).ToString();
                low[i].text = Random.Range(70, 90).ToString();
            }
            else if(icons[i].sprite.name == "Pretty Cloudy")
            {
                description[i].text = "Partly Cloudy";
                high[i].text = Random.Range(70, 90).ToString();
                low[i].text = Random.Range(50, 70).ToString();
            }
            else if (icons[i].sprite.name == "Cloudy")
            {
                description[i].text = "Cloudy";
                high[i].text = Random.Range(55, 70).ToString();
                low[i].text = Random.Range(20, 55).ToString();
            }
            else if(icons[i].sprite.name == "Rainy")
            {
                description[i].text = "Rainy";
                high[i].text = Random.Range(30, 55).ToString();
                low[i].text = Random.Range(10, 20).ToString();
            }
        }

        setWrongVariable();
    }

    void setWrongVariable()
    {
        choice = Random.Range(1, 6);

        switch (choice)
        {
            case 1:
                {
                    int index = Random.Range(0, 7);
                    originalIcon = icons[index].sprite;
                    int newChoice = Random.Range(0, 4);

                    while(icons[index].name == iconChoices[newChoice].name)
                        newChoice = Random.Range(0, 4);

                    icons[index].sprite = iconChoices[newChoice];
                    this.index = newChoice;
                    goal.transform.position = new Vector3(icons[index].gameObject.transform.position.x, icons[index].gameObject.transform.position.y, goal.transform.position.z);

                    break;
                }
            case 2:
                {
                    int index = Random.Range(0, 7);
                    originalText = description[index].text;
                    int newChoice = Random.Range(0, 4);

                    while (description[index].text == desc[newChoice])
                        newChoice = Random.Range(0, 4);

                    description[index].text = desc[newChoice];
                    this.index = newChoice;
                    goal.transform.position = new Vector3(description[index].gameObject.transform.position.x, 
                        description[index].gameObject.transform.position.y, goal.transform.position.z);

                    break;
                }
            case 3:
                {
                    int index = Random.Range(0, 7);
                    originalText = DOW[index].text;
                    int newChoice = Random.Range(0, 7);

                    while (DOW[index].text == days[newChoice])
                        newChoice = Random.Range(0, 7);

                    DOW[index].text = days[newChoice];
                    this.index = newChoice;
                    goal.transform.position = new Vector3(DOW[index].gameObject.transform.position.x, DOW[index].gameObject.transform.position.y, goal.transform.position.z);

                    break;
                }
            case 4:
                {
                    int index = Random.Range(0, 7);
                    originalText = high[index].text;
                    int newHigh = Random.Range(120, 501);

                    high[index].text = newHigh.ToString();
                    this.index = newHigh;
                    goal.transform.position = new Vector3(high[index].gameObject.transform.position.x, high[index].gameObject.transform.position.y, goal.transform.position.z);

                    break;
                }
            case 5:
                {
                    int index = Random.Range(0, 7);
                    originalText = low[index].text;
                    int newLow = Random.Range(-100, -50);

                    low[index].text = newLow.ToString();
                    this.index = newLow;
                    goal.transform.position = new Vector3(low[index].gameObject.transform.position.x, low[index].gameObject.transform.position.y, goal.transform.position.z);

                    break;
                }
        }

        setWrong = true;
        if (originalIcon != null)
        {
            Debug.Log(originalIcon.name);
            GameObject.Find("HUD").GetComponent<GameManager>().SetSign(originalIcon);
        }
        else
        {
            Debug.Log(originalText);
            GameObject.Find("HUD").GetComponent<GameManager>().SetSign(originalText);
        }

        GameObject.FindObjectOfType<GoalPos>().hasTransitioned = false;


    }
}

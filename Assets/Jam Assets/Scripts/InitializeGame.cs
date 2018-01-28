using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeGame : MonoBehaviour {

    string[] headlines = new string[] { "1", "2", "3", "4", "5" };
    string[] days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
    string[] desc = new string[] { "Sunny", "Partly Cloudy", "Cloudy", "Rainy"};
    bool setWrong = false;
    int choice = 0;
    Sprite originalIcon;
    string originalText;
    int index;

    public Image[] icons = new Image[7];
    public Text[] DOW = new Text[7];
    public Text[] description = new Text[7];
    public Text[] high = new Text[7];
    public Text[] low = new Text[7];

    public Text headline;
    public Sprite[] iconChoices = new Sprite[4];

	void Start () {

        Initialize();
	}

    internal void Initialize()
    {
        setWrong = false;
        headline.text = headlines[Random.Range(0, headlines.Length - 1)];

        DOW[0].text = "Sunday";
        DOW[1].text = "Monday";
        DOW[2].text = "Tuesday";
        DOW[3].text = "Wednesday";
        DOW[4].text = "Thursday";
        DOW[5].text = "Friday";
        DOW[6].text = "Saturday";

        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].sprite = iconChoices[Random.Range(0, iconChoices.Length - 1)];

            if(icons[i].sprite.name == "Sun")
            {
                description[i].text = "Sunny";
                high[i].text = Random.Range(90, 110).ToString();
                low[i].text = Random.Range(70, 90).ToString();
            }
            else if(icons[i].sprite.name == "Partly Cloudy")
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
            else
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
        choice = Random.Range(1, 5);

        switch (choice)
        {
            case 1:
                {
                    int index = Random.Range(0, 6);
                    originalIcon = icons[index].sprite;
                    int newChoice = Random.Range(0, 3);

                    while(icons[index].name == iconChoices[newChoice].name)
                        newChoice = Random.Range(0, 3);

                    icons[index].sprite = iconChoices[newChoice];
                    this.index = newChoice;

                    break;
                }
            case 2:
                {
                    int index = Random.Range(0, 6);
                    originalText = description[index].text;
                    int newChoice = Random.Range(0, 6);

                    while (description[index].text == desc[newChoice])
                        newChoice = Random.Range(0, 6);

                    description[index].text = desc[newChoice];
                    this.index = newChoice;

                    break;
                }
            case 3:
                {
                    int index = Random.Range(0, 6);
                    originalText = DOW[index].text;
                    int newChoice = Random.Range(0, 6);

                    while (DOW[index].text == days[newChoice])
                        newChoice = Random.Range(0, 6);

                    DOW[index].text = days[newChoice];
                    this.index = newChoice;

                    break;
                }
            case 4:
                {
                    int index = Random.Range(0, 6);
                    originalText = high[index].text;
                    int newHigh = Random.Range(120, 500);

                    high[index].text = newHigh.ToString();
                    this.index = newHigh;

                    break;
                }
            case 5:
                {
                    int index = Random.Range(0, 6);
                    originalText = low[index].text;
                    int newLow = Random.Range(120, 500);

                    high[index].text = newLow.ToString();
                    this.index = newLow;

                    break;
                }
        }

        setWrong = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour 
{
    int[] scoreBoard = new int[10];
    string[] nameBoard = new string[10];

    Text[] scoreNameText = new Text[10];
    Text[] highScoreText = new Text[10];

	void Start () 
	{
        GrabHighscoreData();

        GrabHighScoreTexts();

        SetHighScoreTexts();
	}

	void Update () 
	{
		
	}

    void GrabHighScoreTexts()
    {
        string highscorePosition;

        for (int i = 0; i < highScoreText.Length; i++)
        {
            highscorePosition = "Highscore" + i.ToString();

            highScoreText[i] = GameObject.Find(highscorePosition).GetComponent<Text>();
        }

        for (int i = 0; i < scoreNameText.Length; i++)
        {
            highscorePosition = "HighscoreName" + i.ToString();

            scoreNameText[i] = GameObject.Find(highscorePosition).GetComponent<Text>();
        }
    }

    void SetHighScoreTexts()
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            highScoreText[i].text = scoreBoard[i].ToString();
            scoreNameText[i].text = nameBoard[i];
        }
    }

    void GrabHighscoreData()
    {
        string highscorePosition;
        string namePosition;

        for (int i = 0; i < scoreBoard.Length; i++)
        {
            highscorePosition = "Highscore" + i.ToString();
            namePosition = "PlayerName" + i.ToString();

            if (PlayerPrefs.HasKey(highscorePosition))
            {
                scoreBoard[i] = PlayerPrefs.GetInt(highscorePosition);

                if (PlayerPrefs.HasKey(namePosition))
                {
                    nameBoard[i] = PlayerPrefs.GetString(namePosition);
                }
                else
                {
                    Debug.Log(namePosition + " Not Found");
                    nameBoard[i] = "???";
                }
            }
            else
            {
                Debug.Log(highscorePosition + " Not Found");
                scoreBoard[i] = 0;
                nameBoard[i] = "???";
            }
        }
    }
}

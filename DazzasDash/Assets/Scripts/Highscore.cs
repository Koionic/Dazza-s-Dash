using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Highscore : MonoBehaviour 
{
    
    GameController gameController;

    GameData gameData;

    [SerializeField]
    GameObject newHighscoreScreen;

    int[] scoreBoard = new int[10];
    string[] nameBoard = new string[10];

    Text[] scoreNameText = new Text[10];
    Text[] highScoreText = new Text[10];

    void Awake()
    {
        gameData = GameObject.Find("DataController").GetComponent<GameData>();
        if (SceneManager.GetActiveScene().name == gameData.gameSceneName)
        {
            gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        }
    }

    void Start () 
	{
        if (SceneManager.GetActiveScene().name == "HighScore")
        {
            GrabHighscoreData();

            GrabHighScoreTexts();

            SetHighScoreTexts();
        }
        gameData.newScoreIsSet = false;
	}

	void Update () 
	{
		
	}

    public void CompareHighScore()
    {
        string scorePosition;

        int newScore = (int)gameController.GetDistance();

        for (int i = 0; i < scoreBoard.Length; i++)
        {
            scorePosition = "Highscore" + (i + 1).ToString();

            if (newScore > PlayerPrefs.GetInt(scorePosition))
            {
                Debug.Log("New Highscore");

                gameData.scorePosition = i + 1;
                gameData.newHighScore = newScore;
                Debug.Log(newScore);
                Debug.Log(gameData.newHighScore);

                gameData.newScoreIsSet = true;

                return;
            }
            else
            {
                gameData.newScoreIsSet = false;
            }
        }
    }

    void GrabHighScoreTexts()
    {
        string highscorePosition;

        for (int i = 0; i < highScoreText.Length; i++)
        {
            highscorePosition = "Highscore" + (i+1).ToString();

            highScoreText[i] = GameObject.Find(highscorePosition).GetComponent<Text>();
        }

        for (int i = 0; i < scoreNameText.Length; i++)
        {
            highscorePosition = "HighscoreName" + (i+1).ToString();

            scoreNameText[i] = GameObject.Find(highscorePosition).GetComponent<Text>();
        }
    }

    void SetHighScoreTexts()
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            highScoreText[i].text = scoreBoard[i].ToString() + " Meters";
            scoreNameText[i].text = nameBoard[i];
        }
    }

    public void SetNewScore()
    {
        string scoreKey;
        string initialKey;

        gameData = GameObject.Find("DataController").GetComponent<GameData>();

        for (int i = scoreBoard.Length; i > gameData.scorePosition; i--)
        {
            scoreKey = "Highscore" + (i).ToString();
            Debug.Log(scoreKey);
            string newScoreKey = "Highscore" + (i - 1).ToString();
            Debug.Log(newScoreKey);

            initialKey = "HighscoreName" + (i).ToString();
            Debug.Log(initialKey);
            string newInitialKey = "HighscoreName" + (i - 1).ToString();
            Debug.Log(newInitialKey);


            PlayerPrefs.SetInt(scoreKey, PlayerPrefs.GetInt(newScoreKey));
            PlayerPrefs.SetString(initialKey, PlayerPrefs.GetString(newInitialKey));

        }

        scoreKey = "Highscore" + gameData.scorePosition.ToString();
        initialKey = "HighscoreName" + gameData.scorePosition.ToString();

        PlayerPrefs.SetInt(scoreKey, gameData.newHighScore);
        Debug.Log(gameData.newInitials);
        PlayerPrefs.SetString(initialKey, gameData.newInitials);
    }

    void GrabHighscoreData()
    {
        string highscorePosition;
        string namePosition;

        for (int i = 0; i < scoreBoard.Length; i++)
        {
            highscorePosition = "Highscore" + (i+1).ToString();
            namePosition = "HighscoreName" + (i+1).ToString();

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

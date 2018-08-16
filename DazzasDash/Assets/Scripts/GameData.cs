using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int dollaryDoos;

    public int scorePosition;
    public int newHighScore;
    public string newInitials;

    public bool newScoreIsSet;

    public string gameSceneName, mainMenuSceneName, highScoreSceneName;

    public bool resetScores = false;


	// Use this for initialization
	void Start () 
    {
		if(resetScores == true)
        {
            PlayerPrefs.DeleteAll();
        }
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}

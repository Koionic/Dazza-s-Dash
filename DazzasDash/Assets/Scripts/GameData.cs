﻿using System.Collections;
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

    public Upgrades equippedUpgrade = Upgrades.DoubleDollaryDoos;

    public Dictionary<Upgrades, int> upgradeInventory = new Dictionary<Upgrades, int>();

    public bool debug = false;


    // Use this for initialization
    void Start () 
    {
		if(resetScores == true)
        {
            PlayerPrefs.DeleteAll();
        }

        if(debug == false)
        {
            if (PlayerPrefs.HasKey("DollaryDoos"))
            {
                dollaryDoos = PlayerPrefs.GetInt("DollaryDoos");
            }
        }

	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}

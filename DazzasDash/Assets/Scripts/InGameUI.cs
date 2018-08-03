using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    GameController gameController;
    DazzaController dazzaController;

    Text dollaryDoosUI;
    Text distanceUI;

	// Use this for initialization
	void Start ()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        dazzaController = GameObject.FindWithTag("Player").GetComponent<DazzaController>();

        dollaryDoosUI = GameObject.FindWithTag("DollaryDooInGameUI").GetComponent<Text>();
        distanceUI = GameObject.FindWithTag("DistanceInGameUI").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        dollaryDoosUI.text = gameController.GetDollaryDoos().ToString();
	}
}

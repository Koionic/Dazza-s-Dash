using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSkinController : MonoBehaviour
{
	private GameData gameData;

	string currentSkin;

	private Animator dazzaAnimator;

	private bool skinSet = false;


	private void Awake()
	{
		gameData = GameObject.Find("DataController").GetComponent<GameData>();

		dazzaAnimator = GetComponent<Animator>();
	}

	private void Start()
	{
		currentSkin = PlayerPrefs.GetString("SelectedSkin");

		switch (currentSkin)
		{
			case "SkinDefault":
				SetParametersToFalse();
				dazzaAnimator.SetBool("Default Skin", true);
				break;

			case "SkinPolice":
				SetParametersToFalse();
				dazzaAnimator.SetBool("Police Skin", true);
				break;

			case "SkinShirtless":
				SetParametersToFalse();
				dazzaAnimator.SetBool("Shirtless Skin", true);
				break;

			case "SkinTradie":
				SetParametersToFalse();
				dazzaAnimator.SetBool("Tradie Skin", true);
				break;
		}
	}



	private void SetParametersToFalse()
	{
		for (int i = 0; i < dazzaAnimator.parameterCount; i++)
		{
			dazzaAnimator.SetBool(dazzaAnimator.parameters[i].name, false);
		}
	}
}

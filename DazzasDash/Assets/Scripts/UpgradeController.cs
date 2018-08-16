using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
	GameController gameController;

	GameData gameData;

	bool DoubleDollaryDoosEnabled = false;
	bool HeadstartEnabled = false;
	bool ReviveEnabled = false;

	void Awake()
	{
		gameData = GameObject.Find("DataController").GetComponent<GameData>();

		if (gameData.equippedUpgrade == Upgrades.DoubleDollaryDoos)
			DoubleDollaryDoosEnabled = true;

		if (gameData.equippedUpgrade == Upgrades.HeadStart)
			HeadstartEnabled = true;

		if (gameData.equippedUpgrade == Upgrades.Revive)
			ReviveEnabled = true;
	}

	public bool DoubleDollaryDoos()
	{
		return DoubleDollaryDoosEnabled;
	}

	public bool Headstart()
	{
		return HeadstartEnabled;
	}

	public bool Revive()
	{
		return ReviveEnabled;
	}
}

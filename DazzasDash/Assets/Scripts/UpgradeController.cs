using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
	GameController gameController;

	GameData gameData;

    private Upgrades equipped = Upgrades.None;

	bool doubleDollaryDoosEnabled = false;
	bool headstartEnabled = false;
	bool reviveEnabled = false;

	void Awake()
	{
		gameData = GameObject.Find("DataController").GetComponent<GameData>();

		if (gameData.equippedUpgrade == Upgrades.DoubleDollaryDoos)
        {
            doubleDollaryDoosEnabled = true;
            gameData.equippedUpgrade = Upgrades.None;
            equipped = Upgrades.DoubleDollaryDoos;
        }
			

		if (gameData.equippedUpgrade == Upgrades.HeadStart)
        {
            headstartEnabled = true;
            gameData.equippedUpgrade = Upgrades.None;
            equipped = Upgrades.HeadStart;
        }
			

		if (gameData.equippedUpgrade == Upgrades.Revive)
        {
            reviveEnabled = true;
            gameData.equippedUpgrade = Upgrades.None;
            equipped = Upgrades.Revive;
        }

        gameData.SaveGameDataUpgradesInventory();



    }

	public bool DoubleDollaryDoos()
	{
		return doubleDollaryDoosEnabled;
	}

	public bool Headstart()
	{
		return headstartEnabled;
	}

	public bool Revive()
	{
		return reviveEnabled;
	}



    private void OnDestroy()
    {
        equipped = Upgrades.None;
    }
}

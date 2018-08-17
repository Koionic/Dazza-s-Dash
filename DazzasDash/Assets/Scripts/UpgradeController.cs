using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
	GameController gameController;

	GameData gameData;

    private Upgrades equipped = Upgrades.None;

	bool DoubleDollaryDoosEnabled = false;
	bool HeadstartEnabled = false;
	bool ReviveEnabled = false;

	void Awake()
	{
		gameData = GameObject.Find("DataController").GetComponent<GameData>();

		if (gameData.equippedUpgrade == Upgrades.DoubleDollaryDoos)
        {
            DoubleDollaryDoosEnabled = true;
            gameData.equippedUpgrade = Upgrades.None;
            equipped = Upgrades.DoubleDollaryDoos;
        }
			

		if (gameData.equippedUpgrade == Upgrades.HeadStart)
        {
            HeadstartEnabled = true;
            gameData.equippedUpgrade = Upgrades.None;
            equipped = Upgrades.HeadStart;
        }
			

		if (gameData.equippedUpgrade == Upgrades.Revive)
        {
            ReviveEnabled = true;
            gameData.equippedUpgrade = Upgrades.None;
            equipped = Upgrades.Revive;
        }

        gameData.SaveGameDataUpgradesInventory();



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



    private void OnDestroy()
    {
        equipped = Upgrades.None;
    }
}

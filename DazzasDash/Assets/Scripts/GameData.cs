using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Dictionary<Upgrades, int> tempUpgradeInventory = new Dictionary<Upgrades, int>();

    // treat this like a bool - 0 is false, 1 is true
    public int inventoryUpdated = 0;

    public bool debug = false;

    private void Awake()
    {
        if (resetScores == true)
        {
            PlayerPrefs.DeleteAll();
        }
    }


    // Use this for initialization
    void Start () 
    {
        if(debug == false)
        {
            if (PlayerPrefs.HasKey("DollaryDoos"))
            {
                dollaryDoos = PlayerPrefs.GetInt("DollaryDoos");
            }

            GetInventoryPlayerPrefs(); 
        }



	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}





    private void OnApplicationFocus(bool hasFocus)
    {
        // if exiting the app
        if(hasFocus == false)
        {
            SetInventoryPlayerPrefs();
        }
        else
        {
            GetInventoryPlayerPrefs();
        }
    }




    private void OnApplicationPause(bool pause)
    {
        if(pause == true)
        {
            SetInventoryPlayerPrefs();
        }
        else
        {
            GetInventoryPlayerPrefs();
        }
    }


    private void OnApplicationQuit()
    {
        SetInventoryPlayerPrefs();
    }



    public void SetInventoryPlayerPrefs()
    {
        int newValue;
        upgradeInventory.TryGetValue(Upgrades.DoubleDollaryDoos, out newValue);
        PlayerPrefs.SetInt("UpgradeInventoryDouble", newValue);
        upgradeInventory.TryGetValue(Upgrades.Revive, out newValue);
        PlayerPrefs.SetInt("UpgradeInventoryRevive", newValue);
        upgradeInventory.TryGetValue(Upgrades.HeadStart, out newValue);
        PlayerPrefs.SetInt("UpgradeInventoryHeadStart", newValue);

        tempUpgradeInventory.TryGetValue(Upgrades.DoubleDollaryDoos, out newValue);
        PlayerPrefs.SetInt("TempUpgradeInventoryDouble", newValue);
        tempUpgradeInventory.TryGetValue(Upgrades.Revive, out newValue);
        PlayerPrefs.SetInt("TempUpgradeInventoryRevive", newValue);
        tempUpgradeInventory.TryGetValue(Upgrades.HeadStart, out newValue);
        PlayerPrefs.SetInt("TempUpgradeInventoryHeadStart", newValue);

        PlayerPrefs.SetInt("InventoryUpdated", inventoryUpdated);

        switch(equippedUpgrade)
        {
            case Upgrades.DoubleDollaryDoos:
                PlayerPrefs.SetString("EquippedUpgrade", "EquippedDouble");
                break;
            case Upgrades.Revive:
                PlayerPrefs.SetString("EquippedUpgrade", "EquippedRevive");
                break;
            case Upgrades.HeadStart:
                PlayerPrefs.SetString("EquippedUpgrade", "EquippedHeadStart");
                break;
            case Upgrades.None:
                PlayerPrefs.SetString("EquippedUpgrade", "EquippedNone");
                break;
        }
        
    }

    public void GetInventoryPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("UpgradeInventoryDouble"))
        {
            upgradeInventory.Remove(Upgrades.DoubleDollaryDoos);
            upgradeInventory.Add(Upgrades.DoubleDollaryDoos, PlayerPrefs.GetInt("UpgradeInventoryDouble"));
        }

        if (PlayerPrefs.HasKey("UpgradeInventoryRevive"))
        {
            upgradeInventory.Remove(Upgrades.Revive);
            upgradeInventory.Add(Upgrades.Revive, PlayerPrefs.GetInt("UpgradeInventoryRevive"));
        }

        if (PlayerPrefs.HasKey("UpgradeInventoryHeadStart"))
        {
            upgradeInventory.Remove(Upgrades.HeadStart);
            upgradeInventory.Add(Upgrades.HeadStart, PlayerPrefs.GetInt("UpgradeInventoryHeadStart"));
        }



        if (PlayerPrefs.HasKey("TempUpgradeInventoryDouble"))
        {
            tempUpgradeInventory.Remove(Upgrades.DoubleDollaryDoos);
            tempUpgradeInventory.Add(Upgrades.DoubleDollaryDoos, PlayerPrefs.GetInt("TempUpgradeInventoryDouble"));
        }

        if (PlayerPrefs.HasKey("TempUpgradeInventoryRevive"))
        {
            tempUpgradeInventory.Remove(Upgrades.Revive);
            tempUpgradeInventory.Add(Upgrades.Revive, PlayerPrefs.GetInt("TempUpgradeInventoryRevive"));
        }

        if (PlayerPrefs.HasKey("TempUpgradeInventoryHeadStart"))
        {
            tempUpgradeInventory.Remove(Upgrades.HeadStart);
            tempUpgradeInventory.Add(Upgrades.HeadStart, PlayerPrefs.GetInt("TempUpgradeInventoryHeadStart"));
        }

        if (PlayerPrefs.HasKey("InventoryUpdated")) inventoryUpdated = PlayerPrefs.GetInt("InventoryUpdated", 0);

        if (PlayerPrefs.HasKey("EquippedUpgrade"))
        {
            string storedUpgradeString;

            storedUpgradeString = PlayerPrefs.GetString("EquippedUpgrade");
            
            switch(storedUpgradeString)
            {
                case "EquippedDouble":
                    equippedUpgrade = Upgrades.DoubleDollaryDoos;
                    break;
                case "EquippedRevive":
                    equippedUpgrade = Upgrades.Revive;
                    break;
                case "EquippedHeadStart":
                    equippedUpgrade = Upgrades.HeadStart;
                    break;
                case "EquippedNone":
                    equippedUpgrade = Upgrades.None;
                    break;
            }
        }

    }




    public void SaveGameDataUpgradesInventory()
    {
        if (SceneManager.GetActiveScene().name.Equals(gameSceneName))
        {
            upgradeInventory = tempUpgradeInventory;
            inventoryUpdated = 1;
            SetInventoryPlayerPrefs(); // this may break! Check this!!!!
        }
    }
}

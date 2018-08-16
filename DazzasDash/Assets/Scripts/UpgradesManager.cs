using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    private Upgrades equipped = Upgrades.None;

    private Dictionary<Upgrades, int> upgradeInventory = new Dictionary<Upgrades, int>();

    private GameData gameData;

    [SerializeField]
    private int doubleCost = 3000, headStartCost = 2000, reviveCost = 1500;

    private void Awake()
    {
        gameData = GameObject.Find("DataController").GetComponent<GameData>();

        upgradeInventory.Add(Upgrades.DoubleDollaryDoos, 0);
        upgradeInventory.Add(Upgrades.HeadStart, 0);
        upgradeInventory.Add(Upgrades.Revive, 0);
    }

    public void Buy(Upgrades inUpgrade)
    {
        switch(inUpgrade)
        {
            case Upgrades.DoubleDollaryDoos:
                if(gameData.dollaryDoos >= doubleCost)
                {
                    Add(inUpgrade);
                }
                break;
            case Upgrades.HeadStart:
                if (gameData.dollaryDoos >= headStartCost)
                {
                    Add(inUpgrade);
                }
                break;
            case Upgrades.Revive:
                if (gameData.dollaryDoos >= reviveCost)
                {
                    Add(inUpgrade);
                }
                break;
        }
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Add(Upgrades inUpgrade)
    {
        int currentCount;
        upgradeInventory.TryGetValue(inUpgrade, out currentCount);

        currentCount++;

        upgradeInventory.Remove(inUpgrade);
        upgradeInventory.Add(inUpgrade, currentCount);

        Debug.Log("UPGRADE: " + inUpgrade.ToString() + "\tx " + currentCount);
    }


    private void OnDestroy()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    private Upgrades equipped = Upgrades.None;

    private Dictionary<Upgrades, int> upgradeInventory = new Dictionary<Upgrades, int>();

    private GameData gameData;

    [SerializeField]
    private int doubleCost = 3000, headStartCost = 2000, reviveCost = 1500;

    [Header("INVENTORY COUNT UI IN ORDER: DOUBLE / REVIVE / HEAD START")]
    [SerializeField]
    private Text[] inventoryCountUI;

    [Header("ITEM COSTS UI IN ORDER: DOUBLE / REVIVE / HEAD START")]
    [SerializeField]
    private Text[] itemCostsUI;

    [SerializeField]
    private Text dollaryDooUI;

    [SerializeField]
    private Sprite[] upgradeIconSprites;

    [SerializeField]
    private Image[] upgradeImageUI;

    [SerializeField]
    private Image equippedImageUI;

    private void Awake()
    {
        gameData = GameObject.Find("DataController").GetComponent<GameData>();

        itemCostsUI[0].text = doubleCost.ToString();
        itemCostsUI[1].text = reviveCost.ToString();
        itemCostsUI[2].text = headStartCost.ToString();

        upgradeImageUI[0].sprite = upgradeIconSprites[0];
        upgradeImageUI[1].sprite = upgradeIconSprites[1];
        upgradeImageUI[2].sprite = upgradeIconSprites[2];

        upgradeInventory.Add(Upgrades.DoubleDollaryDoos, 0);
        upgradeInventory.Add(Upgrades.HeadStart, 0);
        upgradeInventory.Add(Upgrades.Revive, 0);

        UpdateDollaryDoosUI();
    }

    public void Buy(string inUpgrade)
    {
        switch(inUpgrade)
        {
            case "Double":
                if(gameData.dollaryDoos >= doubleCost)
                {
                    Add(Upgrades.DoubleDollaryDoos);
                    SubtractDollaryDoos(doubleCost);
                }
                break;
            case "HeadStart":
                if (gameData.dollaryDoos >= headStartCost)
                {
                    Add(Upgrades.HeadStart);
                    SubtractDollaryDoos(headStartCost);
                }
                break;
            case "Revive":
                if (gameData.dollaryDoos >= reviveCost)
                {
                    Add(Upgrades.Revive);
                    SubtractDollaryDoos(reviveCost);
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


        UpdateUI(inUpgrade, currentCount);
    }


    private void OnDestroy()
    {
        
    }


    void UpdateUI(Upgrades inUpgrade, int theCount)
    {
        switch(inUpgrade)
        {
            case Upgrades.DoubleDollaryDoos:
                inventoryCountUI[0].text = theCount.ToString();
                break;

            case Upgrades.Revive:
                inventoryCountUI[1].text = theCount.ToString();
                break;

            case Upgrades.HeadStart:
                inventoryCountUI[2].text = theCount.ToString();
                break;
        }
    }



    void UpdateDollaryDoosUI()
    {
        dollaryDooUI.text = gameData.dollaryDoos.ToString();
    }

    void SubtractDollaryDoos(int subtract)
    {
        gameData.dollaryDoos -= subtract;
        UpdateDollaryDoosUI();
    }




    public void EquipUpgrade(string inUpgrade)
    {
        switch (inUpgrade)
        {
            case "Double":
                CheckEquip(Upgrades.DoubleDollaryDoos, 0);
                break;

            case "Revive":
                CheckEquip(Upgrades.Revive, 1);
                break;

            case "HeadStart":
                CheckEquip(Upgrades.HeadStart, 2);
                break;
        }
    }



    private void CheckEquip(Upgrades inUpgrade, int arrayIndex)
    {
        int inventoryCount;

        upgradeInventory.TryGetValue(inUpgrade, out inventoryCount);

        // if there are is more than one item in the inventory of the upgrade to equip
        if (inventoryCount > 0)
        {
            // if the upgrade is not already equipped
            if (inUpgrade != equipped)
            {
                // if the equipped upgrade is not equal to none
                if (equipped != Upgrades.None)
                {
                    // add the currently equipped item back to the inventory stocks
                    Add(equipped);
                }

                // remove one from the upgrade to equip
                inventoryCount--;

                // set it in the dictionary
                upgradeInventory.Remove(inUpgrade);
                upgradeInventory.Add(inUpgrade, inventoryCount);

                // set equipped item
                equipped = inUpgrade;

                // update the UI
                UpdateUI(inUpgrade, inventoryCount);

                equippedImageUI.sprite = upgradeIconSprites[arrayIndex];
            }
        }
        

    }
}

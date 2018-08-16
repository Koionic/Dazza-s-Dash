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

    private Color opaque = new Color(1f, 1f, 1f, 1f);
    private Color transparent = new Color(1f, 1f, 1f, 0f);



    private void OnDestroy()
    {
        gameData.tempUpgradeInventory = upgradeInventory;
        gameData.equippedUpgrade = equipped;
    }



    private void Awake()
    {
        gameData = GameObject.Find("DataController").GetComponent<GameData>();

        itemCostsUI[0].text = doubleCost.ToString();
        itemCostsUI[1].text = reviveCost.ToString();
        itemCostsUI[2].text = headStartCost.ToString();

        upgradeImageUI[0].sprite = upgradeIconSprites[0];
        upgradeImageUI[1].sprite = upgradeIconSprites[1];
        upgradeImageUI[2].sprite = upgradeIconSprites[2];

        if(gameData.inventoryUpdated == 1)
        {
            upgradeInventory = gameData.upgradeInventory;
            equipped = gameData.equippedUpgrade;
            gameData.inventoryUpdated = 0;
        }
        else
        {
            upgradeInventory = gameData.tempUpgradeInventory;
            equipped = gameData.equippedUpgrade;
        }

        int newValue;
        upgradeInventory.TryGetValue(Upgrades.DoubleDollaryDoos, out newValue);
        UpdateUI(Upgrades.DoubleDollaryDoos, newValue);
        upgradeInventory.TryGetValue(Upgrades.Revive, out newValue);
        UpdateUI(Upgrades.Revive, newValue);
        upgradeInventory.TryGetValue(Upgrades.HeadStart, out newValue);
        UpdateUI(Upgrades.HeadStart, newValue);

        UpdateDollaryDoosUI();

        UpdateEquippedItemUI();
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



    void Add(Upgrades inUpgrade)
    {
        int currentCount;
        upgradeInventory.TryGetValue(inUpgrade, out currentCount);

        currentCount++;

        upgradeInventory.Remove(inUpgrade);
        upgradeInventory.Add(inUpgrade, currentCount);


        UpdateUI(inUpgrade, currentCount);
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

                UpdateEquippedItemUI();
            }
        }
        

    }



    void UpdateEquippedItemUI()
    {
        switch(equipped)
        {
            case Upgrades.DoubleDollaryDoos:
                equippedImageUI.color = opaque;
                equippedImageUI.sprite = upgradeIconSprites[0];
                break;
            case Upgrades.Revive:
                equippedImageUI.color = opaque;
                equippedImageUI.sprite = upgradeIconSprites[1];
                break;
            case Upgrades.HeadStart:
                equippedImageUI.color = opaque;
                equippedImageUI.sprite = upgradeIconSprites[2];
                break;
            case Upgrades.None:
                equippedImageUI.color = transparent;
                equippedImageUI.sprite = null;
                break;
        }
    }
}

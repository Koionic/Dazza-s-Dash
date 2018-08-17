﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomisationManager : MonoBehaviour
{
    private GameData gameData;

    [SerializeField]
    private Text dollaryDoosCount;

    [System.Serializable]
    public struct Skin
    {
        public DazzaSkin skinType;
        public int skinCost;
        public string skinKey;
        public Image skinImage;
        public Button skinSelectButton;
        public Image skinSelectButtonImage;
        public Text skinSelecButtonText;
        public Button skinCostButton;
        public Image skinCostButtonImage;
        public Text skinCostButtonText;
    }

    [Space(20)]
    [Header("SKIN STUFF")]
    [SerializeField]
    private Skin[] skins;


    [Space(20)]
    [Header("MUSIC STUFF")]
    [SerializeField]
    private Button[] musicCostButtons;



    // treat the int in this dictionary like a bool 0 = false, 1 = true because playerprefs doesn't save bools
    private Dictionary<DazzaSkin, int> skinUnlockedDict = new Dictionary<DazzaSkin, int>();

    private void Awake()
    {
        gameData = GameObject.Find("DataController").GetComponent<GameData>();
    }

    // Use this for initialization
    void Start ()
    {
        GrabSkinDictionaryData();

        UpdateDollaryDooUI();

        for(int i=0; i < skins.Length; i++)
        {
            UpdateSkinUI(i);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void BuySkin(string inSkin)
    {
        switch(inSkin)
        {
            case "SkinDefault":
                CheckCanBuySkin(DazzaSkin.Default, "SkinDefault");
                break;

            case "SkinPolice":
                CheckCanBuySkin(DazzaSkin.Police, "SkinPolice");
                break;

            case "SkinShirtless":
                CheckCanBuySkin(DazzaSkin.Shirtless, "SkinShirtless");
                break;

            case "SkinTradie":
                CheckCanBuySkin(DazzaSkin.Tradie, "SkinTradie");
                break;
        }
    }




    private void CheckCanBuySkin(DazzaSkin inSkin, string inKey)
    {
        int index = GrabSkinArrayIndex(inSkin);

        if(gameData.dollaryDoos >= skins[index].skinCost)
        {
            // deduct dollary doos from game data
            gameData.dollaryDoos -= skins[index].skinCost;
            PlayerPrefs.SetInt("DollaryDoos", gameData.dollaryDoos);

            // change player prefs for unlockable items
            skinUnlockedDict.Remove(inSkin);
            skinUnlockedDict.Add(inSkin, 1);
            PlayerPrefs.SetInt(inKey, 1);

            // update dollary doo UI based on player prefs
            UpdateDollaryDooUI();

            // update skinUI based on playerprefs
            UpdateSkinUI(index);
        }
    }




    private int GrabSkinArrayIndex(DazzaSkin inSkin)
    {
        for(int i=0; i < skins.Length; i++)
        {
            if(skins[i].skinType == inSkin)
            {
                return i;
            }
        }

        return 0;
    }





    private void UpdateDollaryDooUI()
    {
        dollaryDoosCount.text = gameData.dollaryDoos.ToString() ;
    }

    private void UpdateSkinUI(int index)
    {
        int unlockedInt = PlayerPrefs.GetInt(skins[index].skinKey, 0);
        bool unlocked = false;
        if (unlockedInt == 1) unlocked = true;

        Color semiBlack = new Color(0.8f, 0.8f, 0.8f, 0.8f);

        if(unlocked)
        {
            skins[index].skinImage.color = Color.white; // make skin image white
            skins[index].skinSelectButton.interactable = true; // make skin select button interactable
            skins[index].skinSelectButtonImage.color = Color.white; // make skin select button image white

            skins[index].skinCostButton.interactable = false; // make skin cost button not interactable
            skins[index].skinCostButtonImage.color = semiBlack; // make skin cost button image black
            skins[index].skinCostButtonText.text = "PURCHASED!"; // change skin cost button text to "PURCHASED"
        }

        else
        {
            skins[index].skinImage.color = semiBlack; // make skin image white
            skins[index].skinSelectButton.interactable = false; // make skin select button interactable
            skins[index].skinSelectButtonImage.color = semiBlack; // make skin select button image white

            skins[index].skinCostButton.interactable = true; // make skin cost button not interactable
            skins[index].skinCostButtonImage.color = Color.white; // make skin cost button image black
            skins[index].skinCostButtonText.text = skins[index].skinCost.ToString(); // change skin cost button text to "PURCHASED"
        }
    }












    private void GrabSkinDictionaryData()
    {
        skinUnlockedDict.Clear();
        skinUnlockedDict.Add(DazzaSkin.Default, PlayerPrefs.GetInt("SkinDefault", 1));
        skinUnlockedDict.Add(DazzaSkin.Police, PlayerPrefs.GetInt("SkinPolice", 0));
        skinUnlockedDict.Add(DazzaSkin.Shirtless, PlayerPrefs.GetInt("SkinShirtless", 0));
        skinUnlockedDict.Add(DazzaSkin.Tradie, PlayerPrefs.GetInt("SkinTradie", 0));
    }
}
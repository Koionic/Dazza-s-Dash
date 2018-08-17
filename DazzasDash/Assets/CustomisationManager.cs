using System.Collections;
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
            UpdateSkinUI(index, inKey);
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


    private void GrabSkinDictionaryData()
    {
        skinUnlockedDict.Clear();
        skinUnlockedDict.Add(DazzaSkin.Default, PlayerPrefs.GetInt("SkinDefault", 0));
        skinUnlockedDict.Add(DazzaSkin.Police, PlayerPrefs.GetInt("SkinPolice", 0));
        skinUnlockedDict.Add(DazzaSkin.Shirtless, PlayerPrefs.GetInt("SkinShirtless", 0));
        skinUnlockedDict.Add(DazzaSkin.Tradie, PlayerPrefs.GetInt("SkinTradie", 0));
    }


    private void UpdateDollaryDooUI()
    {
        dollaryDoosCount.text = gameData.dollaryDoos.ToString() ;
    }

    private void UpdateSkinUI(int index, string inKey)
    {
        // make skin image white


        // make skin select button interactable
        // make skin select button image white
        // make skin cost button not interactable
        // make skin cost button image black
        // change skin cost button text to "PURCHASED"
    }
}

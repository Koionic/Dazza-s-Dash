using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    private GameData gameData;

    [SerializeField]
    private Text dollaryDooUI;


    private void Awake()
    {
        gameData = GameObject.Find("DataController").GetComponent<GameData>();
    }
    // Use this for initialization
    void Start ()
    {
        UpdateDollaryDoosUI();
	}

    void UpdateDollaryDoosUI()
    {
        dollaryDooUI.text = gameData.dollaryDoos.ToString();
    }


    public void BuyDollaryDoos(int inDD)
    {
        gameData.dollaryDoos += inDD;

        UpdateDollaryDoosUI();
    }
}

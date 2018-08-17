using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    bool isDown = false;

    [SerializeField]
    GameObject uiMenu;

    [SerializeField]
    GameObject externalToggle;

    [SerializeField]
    Text dollaryDooText;

    GameData gameData;

    private void Awake()
    {
        gameData = GameObject.Find("DataController").GetComponent<GameData>();
    }

    void Start()
    {
        GrabDollaryDooData();
    }

    void Update()
    {

    }

    public void Play()
    {

        SceneManager.LoadScene(gameData.gameSceneName);

    }

    public void Upgrades()
    {

        SceneManager.LoadScene("Upgrades");

    }

    public void Customisation()
    {

        SceneManager.LoadScene("Customisation");

    }

    public void Settings()
    {

        SceneManager.LoadScene("Settings");

    }

    public void HighScore()
    {

        SceneManager.LoadScene("HighScore");

    }

    public void Store()
    {

        SceneManager.LoadScene("Store");

    }

    public void Credits()
    {

        SceneManager.LoadScene("Credits");

    }


    public void Quit()
    {
        Application.Quit();
    }


    public void ToggleMenu()
    {

        if (isDown == false)
        {

            isDown = true;
            externalToggle.SetActive(false);
            uiMenu.SetActive(true);

        }
        else if (isDown == true)
        {

            isDown = false;
            externalToggle.SetActive(true);
            uiMenu.SetActive(false);

        }

    }

    void GrabDollaryDooData()
    {
        GameData gameData = GameObject.Find("DataController").GetComponent<GameData>();

        //SetDollaryDooText(dollaryDoos);
        SetDollaryDooText(gameData.dollaryDoos);
    }

    void SetDollaryDooText(int amount)
    {
        string dollaryDooString;
        if (amount < 10)
        {
            dollaryDooString = "0000" + amount.ToString();
        }
        else if (amount < 100 && amount > 10)
        {
            dollaryDooString = "000" + amount.ToString();
        }
        else if (amount < 1000 && amount > 100)
        {
            dollaryDooString = "00" + amount.ToString();
        }
        else if (amount < 10000 && amount > 1000)
        {
            dollaryDooString = "0" + amount.ToString();
        }
        else
        {
            dollaryDooString = amount.ToString();
        }

        dollaryDooText.text = dollaryDooString;
    }
}

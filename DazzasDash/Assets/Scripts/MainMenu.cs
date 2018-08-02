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

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}
	
	public void Play()
	{
	
		SceneManager.LoadScene("GameScene");
	
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

}

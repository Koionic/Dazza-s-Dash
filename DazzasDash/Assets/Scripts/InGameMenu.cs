using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour 
{

    [SerializeField]
    GameObject pauseMenu;

    GameObject pauseButton;

    GameObject deathScreen;

    public void Start()
    {

        pauseButton = GameObject.FindGameObjectWithTag("PauseButton");
        deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");

    }

    private void Update()
    {
        
        if(deathScreen.activeSelf == true)
        {

            pauseButton.SetActive(false);

        }
        else
        {

            pauseButton.SetActive(true);

        }


    }

    public void Resume()
    {

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }

    public void HighScores()
    {

        SceneManager.LoadScene("HighScore");

    }

    public void Pause()
    {

        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }

    public void Retry()
    {

        SceneManager.LoadScene("GameScene");

    }

    public void ToMainMenu()
	{
	
		SceneManager.LoadScene("MainMenu");
	
	}


    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}

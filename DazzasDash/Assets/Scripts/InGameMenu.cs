using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour 
{

    GameData gameData;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject pauseButton;

    [SerializeField]
    GameObject deathScreen;

    [SerializeField]
    GameObject newHighscoreScreen;

    bool isPaused = false;

    public void Awake()
    {
        gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
    }

    public void Start()
    {

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == gameData.gameSceneName)
        {
            if (deathScreen.activeSelf == true)
            {
                pauseButton.SetActive(false);
            }
            else
            {
                pauseButton.SetActive(true);
            }
        }


    }

    public void Resume()
    {

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }

    public void HighScores()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("HighScore");

    }

    public void Pause()
    {

        if (isPaused == false)
        {

            isPaused = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);

        }
        else if (isPaused == true)
        {

            isPaused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);

        }
        

    }

    public void Retry()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene.name);

    }

    public void ToMainMenu()
	{

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
	
	}

    public void QuitGame()
    {
        
    }

    public void DeathScreen()
    {
        if (gameData.newScoreIsSet && deathScreen.gameObject.activeSelf == false)
        {
            newHighscoreScreen.SetActive(true);
        }
        else
        {
            deathScreen.SetActive(true);
        }
    }

}

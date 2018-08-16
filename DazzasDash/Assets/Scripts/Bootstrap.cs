using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script Name:      Bootstrap.cs
//Script Author/s:  Joshua Ganon
//Script Summary:   Keeps the GameController alive while scenes change.

public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private bool debugMode = false;

    private bool doesExist = false;

    private GameData gameData;

    void Awake()
    {
        
        if(debugMode == false) CheckGameObjectExists();

    }

    private void CheckGameObjectExists()
    {
        if (doesExist == false)
        {
            gameData = GetComponent<GameData>();

            DontDestroyOnLoad(this.gameObject);

            if (SceneManager.GetActiveScene().name.Equals("Preload"))
            {
                SceneManager.LoadScene(gameData.mainMenuSceneName);
            }    

            doesExist = true;
        }

        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

}

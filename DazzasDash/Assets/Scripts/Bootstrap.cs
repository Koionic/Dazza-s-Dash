using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script Name:      Bootstrap.cs
//Script Author/s:  Joshua Ganon
//Script Summary:   Keeps the GameController alive while scenes change.

public class Bootstrap : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        SceneManager.LoadScene("MainMenu");
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameController : MonoBehaviour 
{
    [SerializeField]
    GameObject newHighscoreScreen;

    [SerializeField]
    GameObject deathScreen;

    Highscore highscoreController;

    string fullIntials;

    string firstInitial;
    string secondInitial;
    string thirdInitial;

    [SerializeField]
    Text firstInitialText;
    [SerializeField]
    Text secondInitialText;
    [SerializeField]
    Text thirdInitialText;

    void Awake()
    {
        highscoreController = FindObjectOfType<Highscore>().GetComponent<Highscore>();
    }

    void Start () 
	{
        ClearNames();
	}

	void Update () 
	{
        fullIntials = firstInitial + secondInitial + thirdInitial;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (firstInitial == "")
            {
                Debug.Log("You need to enter your initials");
            }
            else
            {
                GameData gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
                gameData.newInitials = fullIntials;
                highscoreController.SetNewScore();
                newHighscoreScreen.SetActive(false);
                deathScreen.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DeleteInitial();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            AddInitial("A");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            AddInitial("B");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            AddInitial("C");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            AddInitial("D");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            AddInitial("E");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            AddInitial("F");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            AddInitial("G");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            AddInitial("H");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            AddInitial("I");
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            AddInitial("J");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            AddInitial("K");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            AddInitial("L");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            AddInitial("M");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            AddInitial("N");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            AddInitial("O");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            AddInitial("P");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            AddInitial("Q");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            AddInitial("R");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            AddInitial("S");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            AddInitial("T");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            AddInitial("U");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            AddInitial("V");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            AddInitial("W");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            AddInitial("X");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            AddInitial("Y");
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            AddInitial("Z");
        }
	}

    void AddInitial (string newInitial)
    {
        if (firstInitial == "")
        {
            firstInitial = newInitial;
            firstInitialText.text = firstInitial;
        }
        else if (secondInitial == "")
        {
            secondInitial = newInitial;
            secondInitialText.text = secondInitial;
        }
        else if (thirdInitial == "")
        {
            thirdInitial = newInitial;
            thirdInitialText.text = thirdInitial;
        }
            else
            {
                Debug.Log("All Initials Full");
            }

    }

    void DeleteInitial()
    {
        if (thirdInitial != "")
        {
            thirdInitial = "";
            thirdInitialText.text = "";
        }
        else if (secondInitial != "")
        {
            secondInitial = "";
            secondInitialText.text = "";
        }
        else if (firstInitial != "")
        {
            firstInitial = "";
            firstInitialText.text = "";
        }
        else
        {
            Debug.Log("There are no initials");
        }
    }

    void ClearNames()
    {
        firstInitial = "";
        firstInitialText.text = "";

        secondInitial = "";
        secondInitialText.text = "";

        thirdInitial = "";
        thirdInitialText.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NameController : MonoBehaviour
{
    bool mobile;

    EventSystem eventSystem;

    [SerializeField]
    GameObject newHighscoreScreen;

    [SerializeField]
    GameObject deathScreen;

    GameData gameData;

    Highscore highscoreController;

    [SerializeField]
    InputField inputField;

    [SerializeField]
    Transform topTextTransform, middleTextTransform;

    void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();

        gameData = GameObject.Find("DataController").GetComponent<GameData>();

        highscoreController = FindObjectOfType<Highscore>().GetComponent<Highscore>();

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            mobile = true;
        }
    }

    private void Start()
    {
        eventSystem.SetSelectedGameObject(inputField.gameObject);
    }

    private void Update()
    {
        if (mobile)
        {
            if (eventSystem.currentSelectedGameObject == inputField.gameObject)
            {
                newHighscoreScreen.transform.position = topTextTransform.position;
            }
            else
            {
                newHighscoreScreen.transform.position = middleTextTransform.position;
            }
        }
    }

    public void AddHighscore()
    {
        gameData.newInitials = inputField.text;
        highscoreController.SetNewScore();
        newHighscoreScreen.SetActive(false);
        deathScreen.SetActive(true);
    }

    public void UpdateText()
    {
        if (inputField.text != "")
        {
            inputField.text = inputField.text.ToUpper();
        }
    }
}
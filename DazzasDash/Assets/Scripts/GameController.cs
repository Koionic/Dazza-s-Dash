using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int dollaryDoos = 0;

    private float distance = 0f;

    private LevelGeneration levelGeneration;

    private GameData gameData;

    private DazzaController dazzaController;

    [SerializeField]
    private BackgroundState backgroundState = BackgroundState.Suburb;

    [SerializeField] float gameSpeed;

    [SerializeField] float rateGameSpeedIncreases = 0.1f;

    private AudioSource soundEffectSource, musicSource;
    
    private void Awake()
    {
        gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
        levelGeneration = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();
        dazzaController = GameObject.FindWithTag("Player").GetComponent<DazzaController>();

        soundEffectSource = transform.GetChild(0).GetComponent<AudioSource>();
        musicSource = transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetDollaryDoos(gameData.dollaryDoos);
    }



    private void Update()
    {
        IncreaseGameSpeed();
    }

    // A timer function
    public float Timer(float timer)
    {
        timer += Time.deltaTime;
        return timer;
    }

    void IncreaseGameSpeed()
    {
        if(!dazzaController.IsDazzaDead())
        {
            if (gameSpeed >= 30f) gameSpeed = 30f;
            else gameSpeed += Time.deltaTime * rateGameSpeedIncreases;
        }
    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }

	public void SetGameSpeed(float speedToSet)
	{
		gameSpeed = Mathf.Lerp(gameSpeed, speedToSet, 1f);
	}

	public BackgroundState GetBackgroundState()
    {
        return backgroundState;
    }

    public void AddDollaryDoo(AudioClip collectedDollaryDooSound)
    {
        dollaryDoos++;

        Debug.Log(collectedDollaryDooSound.name);

        soundEffectSource.clip = collectedDollaryDooSound;
        soundEffectSource.Play();
    }

    public void SetDollaryDoos(int inDollaryDoos)
    {
        dollaryDoos = inDollaryDoos;
        SaveDollaryDoos(dollaryDoos);
    }

    void SaveDollaryDoos(int inDollaryDoos)
    {
        gameData.dollaryDoos = inDollaryDoos;
        PlayerPrefs.SetInt("DollaryDoos", inDollaryDoos);
    }

    public int GetDollaryDoos()
    {
        return dollaryDoos;
    }

    public void SetDistance(float inDistance)
    {
        distance = inDistance;
    }

    public float GetDistance()
    {
        return distance;
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int dollaryDoos;

    private float distance = 0f;

    private LevelGeneration levelGeneration;

    private GameData gameData;

    private DazzaController dazzaController;

	private UpgradeController upgradeController;

    [SerializeField]
    private BackgroundState backgroundState = BackgroundState.Suburb;

    [SerializeField] float gameSpeed;

    [SerializeField] float rateGameSpeedIncreases = 0.1f;

    private AudioSource soundEffectSource, musicSource;

    private int inGameDollaryDoos = 0;

    private bool savedDollaryDoos = false;


    private void Awake()
    {
        gameData = GameObject.Find("DataController").GetComponent<GameData>();
        levelGeneration = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();
        dazzaController = GameObject.FindWithTag("Player").GetComponent<DazzaController>();
		upgradeController = GetComponent<UpgradeController>();

        soundEffectSource = transform.GetChild(0).GetComponent<AudioSource>();
        musicSource = transform.GetChild(1).GetComponent<AudioSource>();

        gameData.ApplySelectedSkinFromPlayerPrefs();

        dazzaController.GetComponent<SkinController>().SetSkin(gameData.selectedSkin);
    }

    private void Start()
    {
        SetDollaryDoos(PlayerPrefs.GetInt("DollaryDoos", 0));

        

        
    }



    private void Update()
    {
        IncreaseGameSpeed();

		if (Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        inGameDollaryDoos++;

		if (upgradeController.DoubleDollaryDoos())
		{
			dollaryDoos++;
			inGameDollaryDoos++;
		}

        soundEffectSource.clip = collectedDollaryDooSound;
        soundEffectSource.Play();
    }

    public void SetDollaryDoos(int inDollaryDoos)
    {
        dollaryDoos = inDollaryDoos;
    }

    public void SaveDollaryDoos()
    {
        if(savedDollaryDoos == false)
        {
            savedDollaryDoos = true;
            gameData.dollaryDoos = dollaryDoos;
            PlayerPrefs.SetInt("DollaryDoos", dollaryDoos);
        }
    }

    public int GetDollaryDoos()
    {
        return dollaryDoos;
    }

    public int GetInGameDollaryDoos()
    {
        return inGameDollaryDoos;
    }

    public void SetDistance(float inDistance)
    {
        distance = inDistance;
    }

    public float GetDistance()
    {
        return distance;
    }

    public void CollectedPowerup(AudioClip powerUpAudio)
    {
        soundEffectSource.clip = powerUpAudio;
        soundEffectSource.Play();
    }


    public AudioSource GetSFXAudioSource()
    {
        return soundEffectSource;
    }
}



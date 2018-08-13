using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int dollaryDoos = 0;

    private float distance = 0f;

    private LevelGeneration levelGeneration;

    private GameData gameData;

    [SerializeField]
    private BackgroundState backgroundState = BackgroundState.Suburb;

    [SerializeField] float gameSpeed;
    
    private void Awake()
    {
        gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
        levelGeneration = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();
    }

    private void Start()
    {
        SetDollaryDoos(gameData.dollaryDoos);
    }

    // A timer function
    public float Timer(float timer)
    {
        timer += Time.deltaTime;
        return timer;
    }

    void IncreaseLevelScrollSpeed()
    {
        // grab speed from levelGeneration.GetLevelScrollSpeed()
        // set speed using levelGeneration.SetLevelScrollSpeed( float)
    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }

	public void SetGameSpeed(float speedToSet)
	{
		gameSpeed = Mathf.Lerp(gameSpeed, speedToSet, 3f);
	}

	public BackgroundState GetBackgroundState()
    {
        return backgroundState;
    }

    public void AddDollaryDoo()
    {
        dollaryDoos++;
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



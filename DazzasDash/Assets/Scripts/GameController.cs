using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private LevelGeneration levelGeneration;

    [SerializeField]
    private BackgroundState backgroundState = BackgroundState.Suburb;

    [SerializeField] float gameSpeed;

    private void Start()
    {
        levelGeneration = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();
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


    public BackgroundState GetBackgroundState()
    {
        return backgroundState;
    }
}



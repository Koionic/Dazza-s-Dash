using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int dollaryDoos = 0;

    private LevelGeneration levelGeneration;

    [SerializeField]
    private BackgroundState backgroundState = BackgroundState.Suburb;

    [SerializeField] float gameSpeed;

<<<<<<< HEAD


    private void Start()
=======
	private void Start()
>>>>>>> 3f1545fba9220eb1d36cbb2870a3144ad065ee3c
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
    }

    public int GetDollaryDoos()
    {
        return dollaryDoos;
    }
}



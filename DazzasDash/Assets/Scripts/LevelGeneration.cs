using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private GameController gameController; // the game controller

    [SerializeField] float levelScrollRate; // The rate of the game speed at which the level prefabs scroll

    private float levelScrollSpeed; // the speed the level objects should scroll at - calculated using the rate and the game speed

    Transform spawnLocation; // Stores the level prefab storing position.




	[SerializeField] GameObject[] levelPrefabs; // An array storing the level prefabs

	[SerializeField] float spawnDelay; // The time between level spawns.






	void Start ()
	{
        // grab references
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        spawnLocation = GameObject.FindWithTag("ObjectSpawnLocation").transform;

        CalculateSpeed();

        // spawn the objects at the spawn delay interval over and over
		InvokeRepeating("SpawnLevelPrefab", spawnDelay, spawnDelay); // invokes them repead
	}

    // this function instantiates the object
	void SpawnLevelPrefab()
	{
        int randIndex = UnityEngine.Random.Range(0, levelPrefabs.Length);

        Instantiate(levelPrefabs[randIndex], spawnLocation.position + levelPrefabs[randIndex].transform.localPosition, Quaternion.identity, transform); // Spawn a random level prefab at the spawn position.
	}

    // this calculates the speed the objects should be scrolling at based on the game speed
    void CalculateSpeed()
    {
        levelScrollSpeed = gameController.GetGameSpeed() * levelScrollRate;
    }

    // this grabs the scroll speed
    public float GetScrollSpeed()
    {
        CalculateSpeed();
        return levelScrollSpeed;
    }
}

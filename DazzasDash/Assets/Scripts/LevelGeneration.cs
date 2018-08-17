using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private GameController gameController; // the game controller

    private DazzaController dazzaController;

    [SerializeField] float levelScrollRate; // The rate of the game speed at which the level prefabs scroll

    private float lastGameSpeed;

    private float levelScrollSpeed; // the speed the level objects should scroll at - calculated using the rate and the game speed

    Transform spawnLocation; // Stores the level prefab storing position.




	[SerializeField] GameObject[] levelPrefabs; // An array storing the level prefabs

	[SerializeField] float spawnDelayMin, spawnDelayMax; // The time between level spawns.

    private float nextSpawnTime;


    private float spawnTimer = 0f;







	void Start ()
	{
        // grab references
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        dazzaController = GameObject.FindWithTag("Player").GetComponent<DazzaController>();

        spawnLocation = GameObject.FindWithTag("ObjectSpawnLocation").transform;

        CalculateSpeed();

        lastGameSpeed = gameController.GetGameSpeed();

        nextSpawnTime = UnityEngine.Random.Range(spawnDelayMin, spawnDelayMax);

    }



    private void Update()
    {
        if (spawnTimer >= nextSpawnTime && !dazzaController.IsDazzaBeingRevived())
        {
            SpawnLevelPrefab();
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
    }

    // this function instantiates the object
    void SpawnLevelPrefab()
	{
        int randIndex = UnityEngine.Random.Range(0, levelPrefabs.Length);

        if(levelPrefabs[randIndex].tag == "MagnetPowerUp" || levelPrefabs[randIndex].tag == "SpeedBoostPowerUp" || levelPrefabs[randIndex].tag == "ShieldPowerUp")
        {
            float randHeight = UnityEngine.Random.Range(0, 6f);

            Instantiate(levelPrefabs[randIndex], spawnLocation.position + new Vector3(levelPrefabs[randIndex].transform.localPosition.x, levelPrefabs[randIndex].transform.localPosition.y + randHeight, levelPrefabs[randIndex].transform.localPosition.z), Quaternion.identity, transform); // Spawn a random level prefab at the spawn position.

            Debug.Log(randHeight);

        }
        else
        {
            Instantiate(levelPrefabs[randIndex], spawnLocation.position + levelPrefabs[randIndex].transform.localPosition, Quaternion.identity, transform); // Spawn a random level prefab at the spawn position.
        }
       

        nextSpawnTime = UnityEngine.Random.Range(spawnDelayMin, spawnDelayMax);

        spawnTimer = 0f;
    }

    // this calculates the speed the objects should be scrolling at based on the game speed
    void CalculateSpeed()
    {
        if (!dazzaController.IsDazzaDead())
        {
            levelScrollSpeed = gameController.GetGameSpeed() * levelScrollRate;
            lastGameSpeed = levelScrollSpeed;
        }
        else
        {
            if (levelScrollRate != 1) levelScrollSpeed = lastGameSpeed;
            else levelScrollSpeed = 0;
        }

        
    }

    // this grabs the scroll speed
    public float GetScrollSpeed()
    {
        CalculateSpeed();
        return levelScrollSpeed;
    }
}

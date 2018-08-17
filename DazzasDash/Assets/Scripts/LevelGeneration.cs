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

    private List<GameObject> levelObjectList = new List<GameObject>();




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
            

            Debug.Log("Ready to spawn something");
            if (gameController.spawnList.Count > 0)
            {
                Debug.Log("they is a prefab in the game list");
                if (gameController.totalLevelObjectsInPlay < gameController.totalSpawnsAllowed)
                {
                    Debug.Log("there's room to spare");
                    if (levelObjectList.Count > 0)
                    {
                        Debug.Log("we have a prefab in our list");
                        if (gameController.spawnList[0].Equals(levelObjectList[0]))
                        {
                            Debug.Log("The prefab matches");
                            SpawnLevelPrefab(levelObjectList[0]);
                            spawnTimer = 0f;
                        }
                        else
                        {
                            Debug.Log("prefab doesnt match");
                            
                        }
                    }
                    else
                    {
                       
                        Debug.Log("no objects queued by this generator");
                    }
                }
                else
                {
                    Debug.Log("too many objects in the scene");
                }
            }
            else
            {
                if (levelObjectList.Count < 5)
                {
                    Debug.Log("Queue new prefab");
                    QueueLevelPrefab();
                }
            }
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
    }



    void QueueLevelPrefab()
    {
        // find the random prefab index
        int randIndex = UnityEngine.Random.Range(0, levelPrefabs.Length);

        // queue the prefab
        gameController.spawnList.Add(levelPrefabs[randIndex]);
        levelObjectList.Add(levelPrefabs[randIndex]);
        Debug.Log(levelPrefabs[randIndex]);
    }

    // this function instantiates the object
    void SpawnLevelPrefab(GameObject inPrefab)
	{
        if(inPrefab.tag == "MagnetPowerUp" || inPrefab.tag == "SpeedBoostPowerUp" || inPrefab.tag == "ShieldPowerUp")
        {
            float randHeight = UnityEngine.Random.Range(0, 6f);

            Instantiate(inPrefab, spawnLocation.position + new Vector3(inPrefab.transform.localPosition.x, inPrefab.transform.localPosition.y + randHeight, inPrefab.transform.localPosition.z), Quaternion.identity, transform); // Spawn a random level prefab at the spawn position.
            Debug.Log("Spawning" + inPrefab);
            Debug.Log(randHeight);

        }
        else
        {
            Instantiate(inPrefab, spawnLocation.position + inPrefab.transform.localPosition, Quaternion.identity, transform); // Spawn a random level prefab at the spawn position.
            Debug.Log("Spawning" + inPrefab);
        }

        gameController.totalLevelObjectsInPlay++;
        Debug.Log("removing" + gameController.spawnList[0]);
        Debug.Log("removing" + levelObjectList[0]);
        gameController.spawnList.RemoveAt(0);
        levelObjectList.RemoveAt(0);

        nextSpawnTime = UnityEngine.Random.Range(spawnDelayMin, spawnDelayMax);
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

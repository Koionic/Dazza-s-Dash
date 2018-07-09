using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : GameController
{

	Transform spawnLocation; // Stores the level prefab storing position.

	[SerializeField]
	GameObject[] levelPrefabs; // An array storing the level prefabs

	[SerializeField]
	float spawnDelay; // The time between level spawns.

	float spawnTimer = 0; // A timer.

	void Start ()
	{
		spawnLocation = GameObject.Find("LevelPrefabSpawnLocation").transform; // Finds the spawn location for the level prefabs and stores it.

		InvokeRepeating("SpawnLevelPrefab", 0, spawnDelay);
	}
	
	void Update ()
	{
		spawnTimer = Timer(spawnTimer); // Runs the timer from the GameController using the spawnTimer.
	}

	void SpawnLevelPrefab()
	{ 
		Instantiate(levelPrefabs[UnityEngine.Random.Range(0, levelPrefabs.Length)], spawnLocation); // Spawn a random level prefab at the spawn position.
	}
}

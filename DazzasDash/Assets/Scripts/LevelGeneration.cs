using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : GameController
{

	Vector2 spawnLocation; // Stores the level prefab storing position.

	[SerializeField]
	GameObject[] levelPrefabs;

	[SerializeField]
	float spawnDelay; // The time between level spawns.

	float spawnTimer = 0; // A timer.

	void Start ()
	{
		spawnLocation = GameObject.Find("LevelPrefabSpawnLocation").transform.position; // Finds the spawn location for the level prefabs and stores it.
	}
	
	void Update ()
	{
		spawnTimer = Timer(spawnTimer); // Runs the timer from the GameController using the spawnTimer.

		if (spawnDelay != null && spawnTimer % spawnDelay == 0); // If a spawn delay is specified and the spawn timer is divisible by the spawn delay.
		{
			
		}
	}
}

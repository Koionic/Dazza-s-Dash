using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour {

	Transform backgroundSpawnLocation;
	
	[SerializeField]
	GameObject[] backgroundPrefabs;
	
	void Start () 
	{
		backgroundSpawnLocation = GameObject.Find("BackgroundSpawnLocation").transform;
	}
	
	void Update () 
	{
		
	}
	
	protected void SpawnBackgroundPrefab(Vector2 inSpawnPosition)
	{
		Instantiate(backgroundPrefabs[0], inSpawnPosition, Quaternion.identity);
	}
}

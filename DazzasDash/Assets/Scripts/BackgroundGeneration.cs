using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{

	Transform backgroundSpawnLocation;
	
	[SerializeField]
	GameObject[] backgroundPrefabs;

    private List<BackgroundScrolling> backgroundList = new List<BackgroundScrolling>();
	
	void Start () 
	{
		backgroundSpawnLocation = GameObject.Find("BackgroundSpawnLocation").transform;
        SpawnBackgroundPrefab();
	}
	
	
	private void SpawnBackgroundPrefab()
	{
        int randIndex = UnityEngine.Random.Range(0, backgroundPrefabs.Length);
		GameObject newBackground = Instantiate(backgroundPrefabs[randIndex], backgroundSpawnLocation.position, Quaternion.identity, transform);

        if (backgroundList.Count > 0)
        {
            int lastIndex = backgroundList.Count - 1;

            newBackground.transform.position = backgroundList[lastIndex].transform.position + new Vector3(40f, 0f, 0f);
        }

        backgroundList.Add(newBackground.GetComponent<BackgroundScrolling>());
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Background"))
        {
            Debug.Log("TRIGGER?!?!?!");
            SpawnBackgroundPrefab();
        }
    }

    public void RemoveFromList(BackgroundScrolling thisComp)
    {
        backgroundList.Remove(thisComp);
    }

}

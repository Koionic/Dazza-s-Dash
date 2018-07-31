using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{
	Transform backgroundSpawnLocation;


    float scrollSpeed;

    [SerializeField]
    float scrollSpeedRate;

    [SerializeField]
    float distanceApart = 45f;

	[SerializeField]
	GameObject[] backgroundPrefabsSuburb, backgroundPrefabsCity;

    GameController gameController;

    private List<BackgroundScrolling> backgroundList = new List<BackgroundScrolling>();
	
	void Start () 
	{
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        backgroundSpawnLocation = GameObject.FindWithTag("BackgroundSpawnLocation").transform;

        if (gameController.GetBackgroundState() == BackgroundState.City)
        {
            SpawnBackgroundPrefab(backgroundPrefabsCity);
        }
        else
        {
            SpawnBackgroundPrefab(backgroundPrefabsSuburb);
        }

	}



    private void SpawnBackgroundPrefab(GameObject[] backgroundArray)
    {
        int randIndex = UnityEngine.Random.Range(0, backgroundArray.Length);
        GameObject newBackground = Instantiate(backgroundArray[randIndex], backgroundSpawnLocation.position, Quaternion.identity, transform);

        if (backgroundList.Count > 0)
        {
            int lastIndex = backgroundList.Count - 1;

            newBackground.transform.position = backgroundList[lastIndex].transform.position + new Vector3(distanceApart, 0f, 0f);
        }

        backgroundList.Add(newBackground.GetComponent<BackgroundScrolling>());
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Background"))
        {
            for (int i = 0; i < backgroundList.Count; i++)
            {
                if (collision.gameObject == backgroundList[i].gameObject)
                {
                    if (gameController.GetBackgroundState() == BackgroundState.City)
                    {
                        SpawnBackgroundPrefab(backgroundPrefabsCity);
                    }
                    else
                    {
                        SpawnBackgroundPrefab(backgroundPrefabsSuburb);
                    }
                }
            }
        }
    }

    public float GetScrollSpeed()
    {
        CalculateSpeed();
        return scrollSpeed;
    }

    public void RemoveFromList(BackgroundScrolling thisComp)
    {
        backgroundList.Remove(thisComp);
    }

    void CalculateSpeed()
    {
        scrollSpeed = gameController.GetGameSpeed() * scrollSpeedRate;
    }

}

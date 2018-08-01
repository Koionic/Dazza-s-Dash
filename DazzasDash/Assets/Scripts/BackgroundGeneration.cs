using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script Name:      BackgroundGeneration.cs
//Script Author/s:  Blake Shortland, Laurence Valentini, Joshua Ganon
//Script Summary:   Spawns backgrounds to be scrolled across the screen and repositions the them so that they line up correctly


public class BackgroundGeneration : MonoBehaviour
{




	Transform backgroundSpawnLocation; // the location that the backgrounds should spawn at

    float scrollSpeed; // the speed at which the backgrounds should move - this is calculated from the game speed

    [SerializeField]
    float scrollSpeedRate; // the rate to multiply the game speed by

    [SerializeField]
    float distanceApart = 45f; // the distance apart that each background should be

	[SerializeField]
	GameObject[] backgroundPrefabsSuburb, backgroundPrefabsCity; // the background prefab arrays for each area - suburb and city

    GameController gameController; // the game controller script

    private List<BackgroundScrolling> backgroundList = new List<BackgroundScrolling>(); // the list to store all the backgrounds that have been instantiated for later reference
	





	void Start () 
	{
        // grab references
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        backgroundSpawnLocation = GameObject.FindWithTag("BackgroundSpawnLocation").transform;

        // spawns the first background
        SpawnBasedOnState();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when a background reached the center of the screen
        if (collision.CompareTag("Background"))
        {
            // if that background is the last background in the list (the last one to be spawned)
            if (collision.gameObject == backgroundList[backgroundList.Count - 1].gameObject)
            {
                // spawn a new background
                SpawnBasedOnState();
            }
        }
    }



    // this function checks to see what background state the game is in and makes sure that the backgrounds spawn from the appropriate array
    void SpawnBasedOnState()
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





    // this function instantiates a new background and repositions it so that it lines up correctly with the last background
    private void SpawnBackgroundPrefab(GameObject[] backgroundArray)
    {
        // choose a random background prefab index from the array and instantiate it in the spawn position
        int randIndex = UnityEngine.Random.Range(0, backgroundArray.Length);
        GameObject newBackground = Instantiate(backgroundArray[randIndex], backgroundSpawnLocation.position, Quaternion.identity, transform);

        // if there is at least one background already in the background list
        if (backgroundList.Count > 0)
        {
            // grab the last backgrounds index
            int lastIndex = backgroundList.Count - 1;

            // reposition the newly spawned background so that it is a set distance apart from the last background spawned
            newBackground.transform.position = backgroundList[lastIndex].transform.position + new Vector3(distanceApart, 0f, 0f);
        }

        // add the newly spawned background to the list
        backgroundList.Add(newBackground.GetComponent<BackgroundScrolling>());
	}






    // this function calculates the speed that the backgrounds should be moving at based on the background generators rate and the current game speed
    void CalculateSpeed()
    {
        scrollSpeed = gameController.GetGameSpeed() * scrollSpeedRate;
    }




    // returns the current scroll speed
    public float GetScrollSpeed()
    {
        CalculateSpeed();
        return scrollSpeed;
    }




    // removes background from the list - this is public so that the background scrolling script attached to each background can call this function
    // when it collides with the background deleter
    public void RemoveFromList(BackgroundScrolling thisComp)
    {
        backgroundList.Remove(thisComp);
    }





}

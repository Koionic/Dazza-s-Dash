using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Name:      BackgroundScrolling.cs
//Script Author/s:  Blake Shortland, Laurence Valentini, Joshua Ganon
//Script Summary:   Scrolls the background at a given speed to the left and destroys the background upon collision

public class BackgroundScrolling : MonoBehaviour
{
    private BackgroundGeneration backgroundGeneration; // reference to the background generation script


    private void Start()
    {
        // grab the reference
        backgroundGeneration = transform.parent.GetComponent<BackgroundGeneration>();
    }

    private void Update()
    {
        // moves the position of the background at the speed goverened by the background generation script
        transform.position += Vector3.left * backgroundGeneration.GetScrollSpeed() * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // if the background collides with the background deleter
        if(other.CompareTag("BackgroundDeleter"))
        {
            // remove it from the background list
            backgroundGeneration.RemoveFromList(this);

            // destroy this background gameobject
            Destroy(gameObject); 
        }
    }


}
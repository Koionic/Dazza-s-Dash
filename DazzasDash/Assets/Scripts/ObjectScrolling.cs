using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectScrolling : MonoBehaviour
{
	LevelGeneration levelGenerator; // the level generator

	void Start ()
	{
        // grab reference
		levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();
	}
	


	void Update ()
	{
        // move the object to the left based on the scroll speed
        transform.position += Vector3.left * levelGenerator.GetScrollSpeed() * Time.deltaTime;
	}



    private void OnTriggerEnter2D(Collider2D other)
    {
        // if collides with the object deleter, destroy the object
        if (other.gameObject.tag == "ObjectDeleter")
        {
            Destroy(gameObject);
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
	{
        // if collides with the object deleter, destroy the object
		if(collision.gameObject.tag == "ObjectDeleter")
		{
            Destroy(gameObject);
		}
	}
}

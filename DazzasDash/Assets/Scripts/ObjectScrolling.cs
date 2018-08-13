using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectScrolling : MonoBehaviour
{
	LevelGeneration levelGenerator; // the level generator

    GameObject player;

	void Start ()
	{
        // grab reference
        if (transform.parent != null) levelGenerator = transform.parent.GetComponent<LevelGeneration>();
        else levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();


        player = GameObject.FindGameObjectWithTag("Player");
    }
	


	void Update ()
	{
        // move the object to the left based on the scroll speed
        //Debug.Log(transform.parent.name + levelGenerator.GetScrollSpeed());
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

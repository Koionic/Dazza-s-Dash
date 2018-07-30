﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    /*[SerializeField]
	float backgroundScrollingSpeed;
	
	BoxCollider2D thisBC;
	float boxColliderXSize;

	void Start () 
	{
		thisBC = GetComponent<BoxCollider2D>();
		boxColliderXSize = thisBC.size.x;
	}
	
	void Update () 
	{
		transform.position += Vector3.left * backgroundScrollingSpeed;
	}
	
	
	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.tag == "MainCamera")
		{
			Vector2 newPosition = new Vector2(transform.position.x + boxColliderXSize, 0f);
			SpawnBackgroundPrefab(newPosition);
			Destroy(gameObject);
		}
	}*/






    [SerializeField]
    private float moveSpeed = 10f;

    private BackgroundGeneration backgroundGeneration;

    private void Start()
    {
        backgroundGeneration = GameObject.Find("BackgroundController").GetComponent<BackgroundGeneration>();
    }

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BackgroundDeleter"))
        {
            backgroundGeneration.RemoveFromList(this);
            Destroy(gameObject); 
        }
    }


}
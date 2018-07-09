using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class LevelScrolling : MonoBehaviour
{
	Rigidbody2D rb2d;
	
	GameController gameController;
	
	GameObject levelDeleter;

	void Start ()
	{
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		levelDeleter = GameObject.Find("LevelDeleter");
		
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		rb2d.velocity = Vector2.left * gameController.GetLevelScrollSpeed();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "LevelDeleter")
		{
			Destroy(gameObject);
		}
	}
}

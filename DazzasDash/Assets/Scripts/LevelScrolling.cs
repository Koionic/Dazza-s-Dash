using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LevelScrolling : MonoBehaviour
{
	Rigidbody2D rb2d;
	
	GameController gameController;

	void Start ()
	{
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		rb2d.velocity = Vector2.left * gameController.GetLevelScrollSpeed();
		
		Debug.Log(gameController.GetLevelScrollSpeed());
	}
}

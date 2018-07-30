using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyMover : MonoBehaviour
{
	Rigidbody2D rb2d;

	LevelGeneration levelGenerator;

	void Start()
	{
		levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();

		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		rb2d.velocity = Vector2.left * levelGenerator.GetEnemyScrollSpeed();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "LevelDeleter")
		{
			Destroy(gameObject);
		}
	}
}

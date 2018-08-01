using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MagpieSwoop : MonoBehaviour
{
	Rigidbody2D rb2d;

	LevelGeneration levelGenerator;

	Transform dazzaTransform;

	bool hasSwooped = false;

	void Start ()
	{
		levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();

		rb2d = GetComponent<Rigidbody2D>();

		dazzaTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		Destroy(gameObject,20);
	}
	
	
	void FixedUpdate ()
	{
		Swoop();
	}

	void Swoop()
	{
		if (rb2d.velocity.y < levelGenerator.GetScrollSpeed())
		{
			rb2d.velocity += (hasSwooped ? Vector2.up : Vector2.down) * levelGenerator.GetScrollSpeed() * Time.fixedDeltaTime;
		}

		if (transform.position.y < dazzaTransform.position.y)
		{
			hasSwooped = true;
		}
	}
}

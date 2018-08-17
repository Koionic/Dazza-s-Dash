using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagpieSwoop : MonoBehaviour
{
	public float dazzaY;

    LevelGeneration levelGeneration;

    Vector3 verticalVelocity = Vector3.zero;

	GameObject objectDeleter;

    public bool hasSwooped = false;

	float speed;

	Animator myAnimator;

	void Start ()
	{
        levelGeneration = transform.parent.GetComponent<LevelGeneration>();

		dazzaY = GameObject.FindWithTag("Player").GetComponent<Transform>().position.y;

		objectDeleter = GameObject.Find("ObjectDeleter");

		speed = (levelGeneration.GetScrollSpeed() * Time.deltaTime);

		myAnimator = GetComponent<Animator>();

		Destroy(gameObject,10);
	}
	
	
	void Update ()
	{
		if (!hasSwooped)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(15f,dazzaY - 0.5f), speed);

			if (transform.position.y <= dazzaY)
			{
				hasSwooped = true;
				myAnimator.SetBool("hasSwooped", true);
			}
		}
		else
			transform.position = Vector3.MoveTowards(transform.position, objectDeleter.transform.position, speed);
	}
}

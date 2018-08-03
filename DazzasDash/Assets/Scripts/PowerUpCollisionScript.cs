using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PowerUpCollisionScript : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
			Destroy(gameObject);
	}
}

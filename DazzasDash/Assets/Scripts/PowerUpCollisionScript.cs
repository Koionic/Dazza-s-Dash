using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollisionScript : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Destroy(gameObject, 0.1f);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollaryDoo : MonoBehaviour
{
    private GameController gameController;

	GameObject player;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

		player = GameObject.FindGameObjectWithTag("Player");
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			gameController.AddDollaryDoo();
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
			Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
        }
    }
}

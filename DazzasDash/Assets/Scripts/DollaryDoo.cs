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

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
			gameController.AddDollaryDoo();
			Destroy(gameObject);
		}

		if (collision.CompareTag("MagnetCollider"))
		{
			Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
		}
	}
}

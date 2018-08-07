using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollaryDoo : MonoBehaviour
{
    private GameController gameController;

    LevelGeneration levelGenerator;

    ObjectScrolling objectScrolling;

    GameObject player;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();

        objectScrolling = GetComponentInParent<ObjectScrolling>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			gameController.AddDollaryDoo();
			Destroy(gameObject);
		}
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetCollider"))
        {
            Debug.Log("Moving Towards Player");

            transform.position = Vector2.Lerp(transform.position, player.transform.position, gameController.GetGameSpeed() * Time.deltaTime);
        }
    }
}

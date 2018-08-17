using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollisionScript : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private AudioClip collectedSound;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
		{
            gameController.CollectedPowerup(collectedSound);
            Destroy(gameObject, 0.1f);
		}
	}
}

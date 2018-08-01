using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollaryDoo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameData gameData = FindObjectOfType<GameData>().GetComponent<GameData>();
            gameData.dollaryDoos++;
            Destroy(gameObject);
        }
    }
}

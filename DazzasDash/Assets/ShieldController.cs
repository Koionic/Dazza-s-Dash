using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private bool deactivate = false;

    private PowerUpController powerUpController;

    private SpriteRenderer thisSR;


    private void Awake()
    {
        powerUpController = GameObject.FindWithTag("Player").GetComponent<PowerUpController>();
        thisSR = GetComponent<SpriteRenderer>();
    }



    private void OnEnable()
    {
        deactivate = false;
        thisSR.enabled = true;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WouldKillDazza"))
        {
            deactivate = true;
            thisSR.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (deactivate == true)
        {
            powerUpController.DeactivateShieldPowerUp();
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    GameController gameController;
    DazzaController dazzaController;

	//Powerup bools
	bool shieldActive = false;
	bool sprintBoostActive = false;
	bool magnetActive = false;

	GameObject shieldCollider;
    GameObject magnetCollider;

    private bool gameSpeedSet = false;
    private float gameSpeedBeforeBoost = 0f;

    [SerializeField]
    private float sprintBoostTime = 5f, sprintBoostGameSpeedRate = 2.5f;



    void Awake()
	{
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        dazzaController = GetComponent<DazzaController>();

        shieldCollider = GameObject.FindGameObjectWithTag("ShieldCollider");
		magnetCollider = GameObject.FindGameObjectWithTag("MagnetCollider");
    }

	void Start ()
	{

	}
	
	void Update ()
	{
		EnableDisableShieldCollider();

        EnableDisableMagnetCollider();

        SprintBoostBehaviour();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("MagnetPowerUp"))
		{
			StartCoroutine(ActivateMagnetPowerUp());
		}

        if (collision.CompareTag("ShieldPowerUp"))
        {
            ActivateShieldPowerUp();
        }

        if(collision.CompareTag("SpeedBoostPowerUp"))
        {
            StartCoroutine(ActivateSprintPowerUp());
        }
	}

	public void ActivateShield(bool stateToSet)
	{
		shieldActive = stateToSet;
	}

	public void ActivateSprintBoost(bool stateToSet)
	{
		sprintBoostActive = stateToSet;
	}

	public void ActivateMagnet(bool stateToSet)
	{
		magnetActive = stateToSet;
	}

    private void ActivateShieldPowerUp()
    {
        ActivateShield(true);
        dazzaController.MakeDazzaInvincible(true);
    }

    public void DeactivateShieldPowerUp()
    {
        ActivateShield(false);
        dazzaController.MakeDazzaInvincible(false);
    }

    IEnumerator ActivateSprintPowerUp()
    {
        ActivateSprintBoost(true);
        gameSpeedBeforeBoost = gameController.GetGameSpeed();
        //gameSpeedSet = false;
        yield return new WaitForSeconds(sprintBoostTime);
        ActivateSprintBoost(false);
    }

    IEnumerator ActivateMagnetPowerUp()
	{
        ActivateMagnet(true);
		yield return new WaitForSeconds(15);
        ActivateMagnet(false);
    }

    void EnableDisableShieldCollider()
    {
        if (shieldActive)
            shieldCollider.SetActive(true);
        else
            shieldCollider.SetActive(false);
    }

    void EnableDisableMagnetCollider()
	{
		if (magnetActive)
			magnetCollider.SetActive(true);
		else
			magnetCollider.SetActive(false);
	}


    void SprintBoostBehaviour()
    {
        if(sprintBoostActive)
        {
            dazzaController.MakeDazzaInvincible(true);

            if(gameSpeedSet == false)
            {
                gameSpeedSet = true;
                gameController.SetGameSpeed(gameController.GetGameSpeed() * sprintBoostGameSpeedRate);
            }
        }
           
        else
        {
            if(gameSpeedSet == true)
            {
                gameSpeedSet = false;
                gameController.SetGameSpeed(gameSpeedBeforeBoost);
                Invoke("MakeDazzaVulnerable", 1.5f);
            }
        }
    }



    void MakeDazzaVulnerable()
    {
        dazzaController.MakeDazzaInvincible(false);
    }
}

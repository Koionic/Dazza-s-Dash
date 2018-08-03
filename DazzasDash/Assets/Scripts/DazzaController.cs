﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazzaController : MonoBehaviour
{

    [SerializeField]
    GameController gameController; // reference to the game controller script

    [SerializeField]
    float jumpForce = 15f; // the speed Dazza jumps

    [SerializeField]
    float maximumJumpTime = .5f; // the maximum time dazza can ascend in his jump for





    float jumpTimer = 0f; // timer to control the jump

    // booleans for determines jump and grounded states
    bool isJumping = false; 
    bool isGrounded = false;

	bool isDead = false; //private bool that tracks if dazza is alive

    Rigidbody2D dazzaRB;

	public Vector2 offset;

    [SerializeField]
    private float timeToIncrementDistance = 1f;

    private float distanceIncrementTimer = 0f;

    private int distance = 0;



	private void Awake()
    {
        dazzaRB = GetComponent<Rigidbody2D>();

		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}







	void Update ()
    {
		if (!isDead)
		{
			DetectUserInputs();

			IncrementTimer();

            IncrementDistance();
		}

        LimitHeight();
    }






    // makes the player jump
    private void FixedUpdate()
    {
        if (isJumping)
        {
            dazzaRB.velocity = (Vector2.up * jumpForce);
        }
	}






    // switches the isJumping boolean when the timer has reached the amount of time allowed to jump
    private void LimitHeight()
    {
        if(jumpTimer >= maximumJumpTime)
        {
            isJumping = false;
        }
    }



    // increments the jump timer when the player is jumping
    private void IncrementTimer()
    {
        if (isJumping)
        {
            jumpTimer = gameController.Timer(jumpTimer);
        }
    }


    // switches the jump boolean if the player presses or releases the jump button
    private void DetectUserInputs()
    {
        if (Input.GetButtonDown("Jump") && jumpTimer == 0f)
        {
            isJumping = true;
            isGrounded = false;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }







    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionMask")
        {
               jumpTimer = 0f;
               isGrounded = true;
        }
    }


	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "WouldKillDazza")
		{
			KillDazza();

			Debug.Log("Dazza should die");
		}
	}


	void KillDazza()
	{
		isDead = true;

		gameController.SetGameSpeed(0f);

		StartCoroutine(KillingDazza());

		Debug.Log("Dazza's dying");
	}

	IEnumerator KillingDazza()
	{
		//Run Dazza's death animation
		yield return new WaitForSeconds(3); //Change this to the length of Dazza's death animation plus a second
		Debug.Log("Dazza's dead");
		//Change scene to whichever scene happens after death
	}


	public bool IsDazzaDead()
	{
		return isDead;
	}




    private void IncrementDistance()
    {
        distanceIncrementTimer = gameController.Timer(distanceIncrementTimer);

        if (distanceIncrementTimer >= timeToIncrementDistance)
        {
            distance += (int)(gameController.GetGameSpeed() / 3f);
            distanceIncrementTimer = 0f;
        }
    }



    public int GetDistance()
    {
        return distance;
    }



}

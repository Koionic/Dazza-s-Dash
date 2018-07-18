using System.Collections;
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

    Rigidbody2D dazzaRB;







    private void Awake()
    {
        dazzaRB = GetComponent<Rigidbody2D>();
    }







	void Update ()
    {
        DetectUserInputs();

        LimitHeight();

        IncrementTimer();

    }






    // makes the player jump
    private void FixedUpdate()
    {
        if (isJumping)
        {
            dazzaRB.velocity = (Vector2.up * jumpForce);
            Debug.Log("is jumping");
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
            if (IsBelow(collision))
            {
                jumpTimer = 0f;
                isGrounded = false;
            }
        }
    }

    //function that calculates whether a collider is below the player
    bool IsBelow(Collsion2D collision)
    {
        //vector that stores which direction the 
        Vector2 offset = (collision.transform.position - transform.position).normalized;
        if (offset.y <= -.95f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

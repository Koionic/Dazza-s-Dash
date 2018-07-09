using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazzaController : MonoBehaviour
{

    [SerializeField]
    GameController gameController;

    //float the controls the speed Dazza jumps
    [SerializeField]
    float jumpForce = 15f, maximumJumpTime = 2f;

    float jumpTimer = 0f;


    bool isJumping = false;

    Rigidbody2D dazzaRB;

    private void Awake()
    {
        dazzaRB = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            //jumpTimer = gameController.Timer
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
	}

    private void FixedUpdate()
    {
        if (isJumping)
        {
            //dazzaRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            dazzaRB.velocity = (Vector2.up * jumpForce);
            Debug.Log("is jumping");
        }
    }



    private void LimitHeight()
    {

    }
}

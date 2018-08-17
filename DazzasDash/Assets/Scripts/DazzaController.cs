using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazzaController : MonoBehaviour
{
    [SerializeField]
    GameObject reviveBottle;

    GameController gameController; // reference to the game controller script

    GameData gameData;

    InGameMenu inGameMenu;

    PowerUpController powerUpController;

    UpgradeController upgradeController;

    [SerializeField] float jumpForce = 15f; // the speed Dazza jumps

    [SerializeField] float maximumJumpTime = .5f; // the maximum time dazza can ascend in his jump for

    [SerializeField] float distanceConstant = 0.1f;

    bool isInvincible = false;

    bool isBeingRevived = false;

    bool alreadyBeenRevived = false;

    bool bufferRemoved = false;

    float timeAfterRevive;
    [SerializeField]
    float reviveTimeBuffer;

    float dazzaDistance = 0f;

    float jumpTimer = 0f; // timer to control the jump

    // booleans for determines jump and grounded states
    bool isJumping = false;
    bool isGrounded = false;

    bool isDead = false; //private bool that tracks if dazza is alive

    Rigidbody2D dazzaRB;

    public Vector2 offset;

    // InGameMenu inGameMenu;




    private void Awake()
    {
        dazzaRB = GetComponent<Rigidbody2D>();

        // inGameMenu = FindObjectOfType<InGameMenu>().GetComponent<InGameMenu>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        powerUpController = transform.GetComponent<PowerUpController>();
        upgradeController = gameController.GetComponent<UpgradeController>();
        gameData = GameObject.Find("DataController").GetComponent<GameData>();
        inGameMenu = FindObjectOfType<InGameMenu>().GetComponent<InGameMenu>();

    }







    void Update()
    {
        if (!isDead)
        {
            DetectUserInputs();

            IncrementTimer();

            CalculateDistance();
        }

        if(alreadyBeenRevived && !bufferRemoved)
        {
            timeAfterRevive += Time.deltaTime;

            if (timeAfterRevive % 0.5f == 0f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }

            if (timeAfterRevive >= reviveTimeBuffer)
            {
                RemoveReviveBuffer();
            }
        }

        LimitHeight();
    }






    // makes the player jump
    private void FixedUpdate()
    {
        if (isJumping && !isDead)
        {
            dazzaRB.velocity = (Vector2.up * jumpForce);
        }
    }






    // switches the isJumping boolean when the timer has reached the amount of time allowed to jump
    private void LimitHeight()
    {
        if (jumpTimer >= maximumJumpTime)
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


    private void CalculateDistance()
    {
        dazzaDistance += (gameController.GetGameSpeed() * Time.deltaTime * distanceConstant);
        gameController.SetDistance(dazzaDistance);
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
        if (collider.gameObject.tag == "WouldKillDazza" && !IsDazzaDead())
        {
            KillDazza();
        }
    }


    void KillDazza()
    {
        if (isInvincible == false)
        {
            isDead = true;

            gameController.PauseScrolling();

            StartCoroutine(KillingDazza());
        }
    }

    IEnumerator KillingDazza()
    {
        //Run Dazza's death animation
        yield return new WaitForSeconds(3); //Change this to the length of Dazza's death animation plus a second

        if (upgradeController.Revive() && !alreadyBeenRevived)
        {
            Debug.Log("Dazza has a revive");
            ReviveDazza();
        }
        else
        {
            gameController.SaveDollaryDoos();

            Highscore highscore = FindObjectOfType<Highscore>().GetComponent<Highscore>();
            if (highscore != null)
            {
                if (!gameData.newScoreIsSet)
                {
                    highscore.CompareHighScore();
                }
                else
                {
                    Debug.Log("score already been set");
                }
            }
            else
            {
                Debug.Log("Highscore script not found. Make sure you're starting from the preload scene");
            }

            inGameMenu.DeathScreen();
        }
    }

    void ReviveDazza()
    {
        StopAllCoroutines();

        Instantiate(reviveBottle, transform);

        isBeingRevived = true;

        alreadyBeenRevived = true;

        MakeDazzaInvincible(true);

        Invoke("FinishRevive", 2f);
    }

    void FinishRevive()
    {
        isBeingRevived = false;

        isDead = false;

        gameController.ResumeScrolling();

        Invoke("RemoveReviveBuffer", 3f);
    }

    void RemoveReviveBuffer()
    {
        bufferRemoved = true;

        MakeDazzaInvincible(false);
    }

    public bool IsDazzaDead()
    {
        return isDead;
    }

    public bool IsDazzaBeingRevived()
    {
        return isBeingRevived;
    }

    public bool IsDazzaInvincible()
    {
        return isInvincible;
    }

    public void MakeDazzaInvincible(bool stateToSet)
    {
        isInvincible = stateToSet;
    }

    public bool GetJumping()
    {
        return isJumping;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}

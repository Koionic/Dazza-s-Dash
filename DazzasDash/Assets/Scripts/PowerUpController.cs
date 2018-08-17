using System.Collections;
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

    [SerializeField]
    private float headStartTime = 10f, headStartSpeedRate = 4f;

    bool headStartActive = false;

    [SerializeField]
    private AudioClip speedBoostSound;

    private AudioSource speedBoostSoundSource;

    UpgradeController upgradeController;

    void Awake()
	{
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        dazzaController = GetComponent<DazzaController>();

        shieldCollider = GameObject.FindGameObjectWithTag("ShieldCollider");
		magnetCollider = GameObject.FindGameObjectWithTag("MagnetCollider");

        speedBoostSoundSource = transform.GetChild(2).GetComponent<AudioSource>();

        upgradeController = gameController.GetComponent<UpgradeController>();
    }

	void Start ()
	{
       if (upgradeController.Headstart())
        {
            StartCoroutine(ActivateSprintPowerUp(true));
        }
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

        if(collision.CompareTag("SpeedBoostPowerUp") && !sprintBoostActive)
        {
            StartCoroutine(ActivateSprintPowerUp(false));
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

    IEnumerator ActivateSprintPowerUp(bool headStart)
    {
        /*  ActivateSprintBoost(true);
          gameSpeedBeforeBoost = gameController.GetGameSpeed();
          yield return new WaitForSeconds(sprintBoostTime);
          ActivateSprintBoost(false); */

        ActivateSprintBoost(true);

        headStartActive = headStart;
        gameSpeedBeforeBoost = (headStart ? 13f : gameController.GetGameSpeed());
        yield return new WaitForSeconds(headStart ? headStartTime : sprintBoostTime);
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
                gameController.SetGameSpeed(gameController.GetGameSpeed() * (headStartActive ? headStartSpeedRate : sprintBoostGameSpeedRate), 1f);
                speedBoostSoundSource.Play();
            }
        }
           
        else
        {
            if(gameSpeedSet == true)
            {
                gameSpeedSet = false;
                gameController.SetGameSpeed(gameSpeedBeforeBoost, 1f);
                Invoke("MakeDazzaVulnerable", 1.5f);
                speedBoostSoundSource.Stop();
                headStartActive = false;
            }
        }
    }



    void MakeDazzaVulnerable()
    {
        dazzaController.MakeDazzaInvincible(false);
    }


    public bool GetSpeedBoostActive()
    {
        return sprintBoostActive;
    }

    public bool GetHeadStartActive()
    {
        return headStartActive;
    }
}

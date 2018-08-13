using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    DazzaController dazzaController;

	//Powerup bools
	bool shieldActive = false;
	bool sprintBoostActive = false;
	bool magnetActive = false;

	GameObject shieldCollider;
    GameObject magnetCollider;

    void Awake()
	{
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
        yield return new WaitForSeconds(15);
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
}

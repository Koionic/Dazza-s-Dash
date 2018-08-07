using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
	//Powerup bools
	bool shieldActive = false;
	bool sprintBoostActive = false;
	bool magnetActive = false;

	CircleCollider2D shieldCollider;
    CircleCollider2D magnetCollider;

    void Awake()
	{
		magnetCollider = transform.GetChild(0).GetComponentInChildren<CircleCollider2D>();
	}

	void Start ()
	{

	}
	
	void Update ()
	{
		EnableDisableMagnetCollider();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("MagnetPowerUp"))
		{
			StartCoroutine(ActivateMagnetPowerUp());
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

    IEnumerator ActivateShieldPowerUp()
    {
        ActivateShield(true);
        yield return new WaitForSeconds(15);
        ActivateShield(false);
    }

    IEnumerator ActivateSprintPowerUp()
    {
        ActivateSprintBoost(true);
        yield return new WaitForSeconds(15);
        ActivateSprintBoost(false);
    }

    IEnumerator ActivateMagnetPowerUp()
	{

		yield return new WaitForSeconds(15);

	}

    void EnableDisableShieldCollider()
    {
        if (shieldActive)
            shieldCollider.enabled = true;
        else
            shieldCollider.enabled = false;
    }

    void EnableDisableMagnetCollider()
	{
		if (magnetActive)
			magnetCollider.enabled = true;
		else
			magnetCollider.enabled = false;
	}
}

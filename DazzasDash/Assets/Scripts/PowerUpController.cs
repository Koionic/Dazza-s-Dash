using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
	//Powerup bools
	bool shieldActive = false;
	bool sprintBoostActive = false;
	bool magnetActive = false;

	CircleCollider2D magnetCollider;

	void Awake()
	{
		magnetCollider = GetComponent<CircleCollider2D>();
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
		if (collision.tag == "MagnetPowerUp")
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

	IEnumerator ActivateMagnetPowerUp()
	{
		ActivateMagnet(true);
		yield return new WaitForSeconds(15);
		ActivateMagnet(false);
	}

	void EnableDisableMagnetCollider()
	{
		if (magnetActive)
			magnetCollider.enabled = true;
		else
			magnetCollider.enabled = false;
	}
}

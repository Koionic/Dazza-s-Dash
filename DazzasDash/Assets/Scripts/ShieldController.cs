using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private bool deactivate = false;

    private PowerUpController powerUpController;

    private SpriteRenderer thisSR;

    private AudioSource thisAudioSource;

    [SerializeField]
    private AudioClip activateSound, deactivateSound, activeSound;

    private GameController gameController;

    DazzaController dazzaController;

    private void Awake()
    {
        powerUpController = GameObject.FindWithTag("Player").GetComponent<PowerUpController>();
        thisSR = GetComponent<SpriteRenderer>();
        thisAudioSource = GetComponent<AudioSource>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }



    private void OnEnable()
    {
        deactivate = false;
        thisSR.enabled = true;
        thisAudioSource.clip = activateSound;
        thisAudioSource.Play();
        Invoke("ShieldActiveSound", thisAudioSource.clip.length);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WouldKillDazza") && !powerUpController.GetSpeedBoostActive())
        {
            Debug.Log("Fart");
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            deactivate = true;
            thisSR.enabled = false;
            thisAudioSource.clip = deactivateSound;
            thisAudioSource.loop = false;
            thisAudioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (deactivate == true)
        {
            powerUpController.DeactivateShieldPowerUp();
        }
    }


    private void ShieldActiveSound()
    {
        thisAudioSource.clip = activeSound;
        thisAudioSource.loop = true;
        thisAudioSource.Play();
    }
}

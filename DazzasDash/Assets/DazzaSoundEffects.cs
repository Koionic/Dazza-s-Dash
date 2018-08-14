using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazzaSoundEffects : MonoBehaviour
{
    private DazzaController dazzaController;
    private GameController gameController;

    private AudioSource thisAudioSource;

    [SerializeField]
    private AudioClip[] footsteps;
    private int footstepsIndex = 0;

    [SerializeField]
    private float timeBetweenSteps = 0.5f;
    private float stepTimer = 0f;

    [SerializeField]
    private AudioClip jump, land, dead;

	// Use this for initialization
	void Start ()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        dazzaController = GetComponent<DazzaController>();

        thisAudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!dazzaController.IsDazzaDead())
        {
            if (dazzaController.IsGrounded())
            {
                if (thisAudioSource.clip == jump)
                {
                    thisAudioSource.clip = land;
                    thisAudioSource.Play();
                }
                else Running();

            }
            else
            {
                if (thisAudioSource.clip != jump)
                {
                    thisAudioSource.clip = jump;
                    thisAudioSource.Play();
                }
            }
        }
        else
        {
            if (thisAudioSource.clip != dead)
            {
                thisAudioSource.clip = dead;
                thisAudioSource.Play();
            }
        }
        
	}


    void Running()
    {
        if (stepTimer >= timeBetweenSteps)
        {
            thisAudioSource.clip = footsteps[footstepsIndex];
            thisAudioSource.Play();

            footstepsIndex++;

            if (footstepsIndex == footsteps.Length) footstepsIndex = 0;

            stepTimer = 0f;
        }
        else
        {
            stepTimer = gameController.Timer(stepTimer);
        }
    }
}

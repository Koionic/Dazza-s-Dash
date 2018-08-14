using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource[] channels;

    [SerializeField]
    private AudioClip[] songs;

    private bool channelOnePlaying = true;

	// Use this for initialization
	void Start ()
    {
        channels = GetComponents<AudioSource>();

        int randSongIndex = Random.Range(0, songs.Length);

        channels[0].clip = songs[randSongIndex];

        randSongIndex = Random.Range(0, songs.Length);

        channels[1].clip = songs[randSongIndex];

        channels[0].Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ChangeSong();
	}


    void ChangeSong()
    {
        if (songs.Length > 1)
        {
            if (channelOnePlaying == true && channels[0].isPlaying == false)
            {
                channelOnePlaying = false;
                channels[0].Stop();
                channels[1].Play();

                int randSongIndex = Random.Range(0, songs.Length);

                channels[0].clip = songs[randSongIndex];
            }

            if (channelOnePlaying == false && channels[1].isPlaying == false)
            {
                channelOnePlaying = true;
                channels[0].Play();
                channels[1].Stop();

                int randSongIndex = Random.Range(0, songs.Length);

                channels[1].clip = songs[randSongIndex];
            }
        }
        else
        {
            channels[0].loop = true;
        }
    }

}

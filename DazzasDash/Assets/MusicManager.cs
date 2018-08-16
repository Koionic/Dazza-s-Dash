using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource[] channels;

    [SerializeField]
    private AudioClip[] songs;

    private bool channelOnePlaying = true;

    private int nextSongIndex;

	// Use this for initialization
	void Start ()
    {
        channels = GetComponents<AudioSource>();

        int randSongIndex = Random.Range(0, songs.Length);

        channels[0].clip = songs[randSongIndex];

        if (songs.Length <= 2)
        {
            if (randSongIndex == 0) randSongIndex = 1;
            else randSongIndex = 0;
        }
        else
        {
            randSongIndex = FindNewSong(randSongIndex);

            nextSongIndex = randSongIndex;
        }


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

                int randSongIndex = FindNewSong(nextSongIndex);

                nextSongIndex = randSongIndex;

                channels[0].clip = songs[randSongIndex];
            }

            if (channelOnePlaying == false && channels[1].isPlaying == false)
            {
                channelOnePlaying = true;
                channels[0].Play();
                channels[1].Stop();

                int randSongIndex = FindNewSong(nextSongIndex);

                nextSongIndex = randSongIndex;

                channels[1].clip = songs[randSongIndex];
            }
        }
        else
        {
            channels[0].loop = true;
        }
    }



    int FindNewSong(int currentSongIndex)
    {
        if (currentSongIndex == 0)
        {
            return Random.Range(1, songs.Length);
        }
        else if (currentSongIndex == (songs.Length - 1))
        {
            return Random.Range(0, (songs.Length - 1));
        }
        else
        {
            int newIndex1 = Random.Range(0, currentSongIndex);
            int newIndex2 = Random.Range(currentSongIndex + 1, songs.Length);

            int coinToss = Random.Range(0, 2);

            if (coinToss == 0) return newIndex1;
            else return newIndex2;
        }
    }

}

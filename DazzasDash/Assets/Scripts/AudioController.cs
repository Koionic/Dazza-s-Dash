using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
	public Slider musicSlider;
	public Slider sfxSlider;
	public AudioMixer masterMixer;

	int i = 0;

	private void Update()
	{
		if (SceneManager.GetActiveScene().name == "Settings")
		{
			if (i == 0)
			{
				musicSlider = GameObject.Find("Music Slider").GetComponent<Slider>();
				sfxSlider = GameObject.Find("SFX Slider").GetComponent<Slider>();

				i++;
			}
			
		}
		else
			i = 0;
	}

	public void SetMusicSlider()
	{
		masterMixer.SetFloat("Music", musicSlider.value);
	}

	public void SetSFXSlider()
	{
		masterMixer.SetFloat("SFX", sfxSlider.value);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
	Slider musicSlider;
	Slider sfxSlider;
	AudioMixerGroup musicMixer;
	AudioMixerGroup sfxMixer;

	private void Start()
	{
		if (SceneManager.GetActiveScene().name == "Settings")
		{
			musicSlider = GameObject.Find("Music Slider").GetComponent<Slider>();
			sfxSlider = GameObject.Find("SFX Slider").GetComponent<Slider>();
		}
	}

	public void SetMusicSlider()
	{
		musicMixer.audioMixer.SetFloat("Music", musicSlider.value);
	}

	public void SetSFXSlider()
	{
		musicMixer.audioMixer.SetFloat("SFX", sfxSlider.value);
	}
}

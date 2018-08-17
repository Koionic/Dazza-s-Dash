using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsUIController : MonoBehaviour
{
	AudioController audioController;

	void Awake()
	{
		audioController = GameObject.Find("DataController").GetComponent<AudioController>();
	}

	public void SetMusicSlider()
	{
		audioController.SetMusicSlider();
	}

	public void SetSFXSlider()
	{
		audioController.SetSFXSlider();
	}
}

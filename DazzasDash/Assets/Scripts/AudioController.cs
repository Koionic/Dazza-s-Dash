using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
	Slider musicSlider;
	Slider sfxSlider;

	private void Start()
	{
		if (SceneManager.GetActiveScene().name == "Settings")
		{
			musicSlider = GameObject.Find("Music Slider").GetComponent<Slider>();
			sfxSlider = GameObject.Find("SFX Slider").GetComponent<Slider>();
		}
	}
}

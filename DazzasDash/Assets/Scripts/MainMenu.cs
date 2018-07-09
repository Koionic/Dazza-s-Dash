using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void Play()
	{
	
		SceneManager.LoadScene("GameScene");
	
	}
	
	public void Upgrades()
	{
	
		SceneManager.LoadScene("UI - Upgrades");
	
	}
	
	public void Customisation() 
	{
	
		SceneManager.LoadScene("UI - Customisation");
	
	}
	
	public void Settings() 
	{
	
		SceneManager.LoadScene("UI - Settings");
	
	}
	
	public void HighScore()
	{
	
		SceneManager.LoadScene("UI - HighScore");
	
	}
	
	public void Store() 
	{
	
		SceneManager.LoadScene("UI - Store");
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{

	//bool isDown = false;
	
	
	//public GameObject uiDropdown;
	
	
	//public Transform disabled;

	void Start () 
	{
		
	}
	
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
	
	//public DropDown()
	//{
	
		//if(isDown == false)
		//{
		
			//uiDropdown.transform.position = new Vector3 (disabled.position.transform, transform.position);
		
		//}
	
	//}
	//mac is aids. its suppose to be a drop down menu thing. gonna fix this on a real computer :P -John
}

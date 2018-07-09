using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	float LevelScrollSpeed; // The speed at which the level prefabs scroll

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

	// A timer function
	public float Timer(float timer)
	{
		timer += Time.deltaTime;
		return timer;
	}

	void IncreaseLevelScrollSpeed()
	{

	}
}

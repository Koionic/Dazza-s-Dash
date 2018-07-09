using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCollision : MonoBehaviour 
{

	private BoxCollider2D camBC;
	
	// Use this for initialization
	void Start () 
	{
		camBC = GetComponent<BoxCollider2D>();
		
		Vector2 newSize = new Vector2((2f * Camera.main.orthographicSize) * Camera.main.aspect, 2f * Camera.main.orthographicSize);
		
		camBC.size = newSize;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}

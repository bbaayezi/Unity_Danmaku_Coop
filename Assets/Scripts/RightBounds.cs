using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBounds : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnCollisionEnter2D(Collision2D other) 
	{
		Debug.Log(other.transform.name);
		Destroy(other.gameObject);
	}
}

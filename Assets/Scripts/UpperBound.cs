using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBound : MonoBehaviour 
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
		Debug.Log("Collision!");
		if (other.transform.tag == "SelfBullets")
		{
			Destroy(other.gameObject);
		}	
	}
}

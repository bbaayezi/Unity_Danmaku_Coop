using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBounds : MonoBehaviour 
{
	public delegate void LeftBoundsEvent(bool flag);
	public static event LeftBoundsEvent OnEnemyEnter;
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
		if (other.transform.name.Contains("enemy"))
		{
			OnEnemyEnter?.Invoke(true);
		}
	}
}

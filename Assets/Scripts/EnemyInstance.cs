using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour {

	// Use this for initialization
	private int life = 15;
	public GameObject Path;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnCollisionEnter2D(Collision2D other) 
	{
		Debug.Log("Enemy being hit!");
		life--;
		if (life < 0)
		{
			Destroy(gameObject);
			Destroy(Path.gameObject);
		}

	}

}

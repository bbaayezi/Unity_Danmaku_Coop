using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject EnemySmall;
	// Use this for initialization
	void Start () 
	{
		SpawnProcedure();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	async void SpawnProcedure()
	{
		int i = 0;
		while (i < 4)
		{
			Instantiate(EnemySmall, new Vector3(0, 3.5f, -5f), Quaternion.Euler(0, 0, 0));
			i++;
			await Task.Delay(TimeSpan.FromSeconds(3f));
		}
	}
}

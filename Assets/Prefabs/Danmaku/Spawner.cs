using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public GameObject spawnObj;
	public float rotationOffset;
	public int spawnOffset;
	private int _frame;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.rotation *= Quaternion.Euler(0, 0, rotationOffset * Time.deltaTime);
		_frame++;
		if (_frame == spawnOffset)
		{
			_frame = 0;
			Instantiate(spawnObj, transform.position, transform.rotation);
		}
	}
}

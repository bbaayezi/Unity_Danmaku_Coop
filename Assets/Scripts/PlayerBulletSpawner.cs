using System.Collections;
using System.Collections.Generic;
using Project.Standard.Interface;
using System;
using System.Threading;
using UnityEngine;

public class PlayerBulletSpawner : MonoBehaviour, ISpawnable 
{
	// Binding area
	public GameObject bullet;
	private int frameCount = 0;
	private float m_ShootInput;
	public delegate void SpawnEvent(GameObject newBullet);

	public static event SpawnEvent OnFinishedSpawn;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// shoot every 3 frames
		// check the input
		m_ShootInput = Input.GetAxis("Shoot");
		if (m_ShootInput > .1f)
		{
			frameCount++;
			if(frameCount == 3)
			{
				SpawnBullet();
				
				// reset frame count
				frameCount = 0;
			}
		}
		
	}

	public void SpawnBullet()
	{
		GameObject newBulletLeft = Instantiate(bullet, transform.position + new Vector3(0.15f, -0.3f, 0), Quaternion.Euler(0, 0, 90), transform);
		GameObject newBulletRight = Instantiate(bullet, transform.position + new Vector3(-0.15f, -0.3f, 0), Quaternion.Euler(0, 0, 90), transform);
		// Emit event

		newBulletLeft.GetComponent<Rigidbody2D>().velocity = Vector2.up * 35;
		newBulletRight.GetComponent<Rigidbody2D>().velocity = Vector2.up * 35;
		// destroy
	}

}

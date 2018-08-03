using System.Collections;
using System.Collections.Generic;
using Project.Standard.Interface;
using System.Threading;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour, IBulletControl
{

	// Use this for initialization
	private int frameCount = 0;
	private GameObject bulletRef;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		frameCount++;
		if (frameCount == 3) frameCount = 0;
	}

	private void OnEnable() 
	{
		// handle with bullet spawn event
		PlayerBulletSpawner.OnFinishedSpawn += Shoot;
	}

	private void OnDisable() 
	{
		PlayerBulletSpawner.OnFinishedSpawn -= Shoot;
	}

	public void Shoot(GameObject newBullet)
	{
		// Debug.Log("Shooting!");
		// // Task.Run()
		// // shoot the bullet
		// newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * 40;
	}

	public void ClearBullets()
	{

	}
}

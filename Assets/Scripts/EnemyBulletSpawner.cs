using System.Collections;
using System.Collections.Generic;
using Project.Standard.Interface;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour, ISpawnable 
{

	public GameObject Bullet;
	public GameObject Parent;
	private bool spawnFlag = false;
	private int frameCount = 0;
	Vector3 bulletSpawnPosition;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		frameCount++;
		if (spawnFlag && frameCount % 3 == 0)
		{
			GameObject bulletGroup = Instantiate(Bullet, bulletSpawnPosition, transform.rotation, transform);
			foreach(Rigidbody2D bullet in bulletGroup.GetComponentsInChildren<Rigidbody2D>())
			{
				bullet.velocity = bullet.transform.TransformDirection(new Vector2(0, -1)) * 2;
			}
			spawnFlag = false;
			frameCount = 0;
		}
	}

	private void OnEnable() 
	{
		EnemyController.OnBulletSpawnPoint += SpawnBullet;
	}

	private void OnDisable() 
	{
		EnemyController.OnBulletSpawnPoint -= SpawnBullet;
	}

	public void SpawnBullet()
	{
		// Debug.Log("Spawn point reached!");
		spawnFlag = true;
		bulletSpawnPosition = Parent.transform.position;
		// shoot the bullet
		
	}
}

using System.Collections;
using System.Collections.Generic;
using Project.Standard.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyControl 
{
	// Use this for initialization
	public GameObject[] Enemies;
	private int frameCount = 0;
	private float m_VerSpeed = .8f;
	private float m_HorSpeed = .5f;
	public delegate void PathFollowEvent();
	public static event PathFollowEvent OnBulletSpawnPoint;
	void Start () 
	{
		// SpeedChange();
		SpawnBullets();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		frameCount++;
		if (frameCount == 30)
		{
			// spawn bullet
			// OnBulletSpawnPoint?.Invoke();
			m_VerSpeed -= .12f;
			m_HorSpeed += .1f;
			frameCount = 0;
		}
		DoMotionClip();
	}

	public void DoMotionClip()
	{
		// TODO: try catch
		foreach(GameObject enemy in Enemies)
		{
			enemy.transform.localPosition += -Vector3.up * Time.fixedDeltaTime * m_VerSpeed;
			enemy.transform.localPosition += Vector3.right * Time.fixedDeltaTime * m_HorSpeed;
		}
		
	}

	private async void SpeedChange()
	{
		await Task.Delay(TimeSpan.FromSeconds(1f));
		
		// m_HorSpeed += .1f;
	}

	private async void SpawnBullets()
	{
		int i = 0;
		// await Task.Delay(TimeSpan.FromSeconds(.5f));
		for (int j = Enemies.Length - 1 ; j >= 0; j--)
		{
			await Task.Delay(TimeSpan.FromSeconds(.5f));
			Enemies[j].GetComponentInChildren<EnemyBulletSpawner>().SpawnBullet();
		}
		while (i < 3)
		{
			for (int j = Enemies.Length - 1 ; j >= 0; j--)
			{
				await Task.Delay(TimeSpan.FromSeconds(.3f));
				Enemies[j].GetComponentInChildren<EnemyBulletSpawner>().SpawnBullet();
			}
			i++;
		}
	}

	
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine;
using UnityEditor;

public class Debugger : MonoBehaviour 
{
	// Use this for initialization
    public GameObject Enemy;
    public GameObject EnemyMedium;
    public GameObject EnemyMediumSpawnPoint;
    public GameObject EnemySmallSpawnPoint;
    public GameObject Bullet;
    public GameObject Parent;
    public GameObject ParticleSys;
    private ParticleSystem Ps;
    public GameObject EffectHolder;
    private int frameCount = 0;
	void Start () 
    {
        // SpawnEnemy();
        // SpawnBullet();
        // SpawnMediumEnemy();
        // Ps = ParticleSys.GetComponent<ParticleSystem>();
        // Ps.Play();
	}
	
	// Update is called once per frame
	void Update () 
    {
		frameCount++;
        if (frameCount == 60)
        {
            for (int i = 0; i < EffectHolder.GetComponentsInChildren<ParticleSystem>().Length - 2; i++)
            {
                Destroy(EffectHolder.GetComponentsInChildren<ParticleSystem>()[i].gameObject);
            }
            frameCount = 0;
        }
        // if(frameCount == 120)
        // {
        //     frameCount = 0;
        //     Instantiate(Bullet, Bullet.transform.position, Bullet.transform.rotation);
        // }
	}

    async void SpawnEnemy()
    {
        await Task.Delay(TimeSpan.FromSeconds(1.5f));
        Instantiate(Enemy, EnemySmallSpawnPoint.transform.position + 1.5f * Vector3.right, Enemy.transform.rotation, Parent.transform);
        await Task.Delay(TimeSpan.FromSeconds(1.5f));
        Instantiate(Enemy, EnemySmallSpawnPoint.transform.position, Enemy.transform.rotation, Parent.transform);
        await Task.Delay(TimeSpan.FromSeconds(1.5f));
        Instantiate(Enemy, EnemySmallSpawnPoint.transform.position - Vector3.right, Enemy.transform.rotation, Parent.transform);
        await Task.Delay(TimeSpan.FromSeconds(1.5f));
        Instantiate(Enemy, EnemySmallSpawnPoint.transform.position + Vector3.right, Enemy.transform.rotation, Parent.transform);
    }

    async void SpawnMediumEnemy()
    {
        await Task.Delay(TimeSpan.FromSeconds(1.5f));
        Instantiate(EnemyMedium, EnemyMediumSpawnPoint.transform.position, Enemy.transform.rotation, Parent.transform);
    }

    async void SpawnBullet()
    {
        await Task.Delay(TimeSpan.FromSeconds(2f));
        foreach(SpriteRenderer bullet in Bullet.GetComponentsInChildren<SpriteRenderer>())
        {
            Instantiate(bullet.gameObject, Bullet.transform.position, bullet.transform.rotation, Bullet.transform);
        }
    }
}

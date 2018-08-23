using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;

[RequireComponent(typeof(EnemyMotionController), typeof(EnemyBulletController), typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour 
{
    public delegate void SpawnEvent(GameObject _this);
    // private GameObject BulletGroupHolder;
    // public GameObject[] Bullets;
    private int frameCount;
    private int life = 30;
    public delegate void EnemyDestroyEvent(Transform trans);
    public static EnemyDestroyEvent OnDestroy;
    public GameObject ParticleSys;
    private ParticleSystem Ps;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {   
	}

    void SpawnBullet()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name.Contains("playerBullet"))
        {
            life--;
            if (life == 0)
            {
                // OnDestroy?.Invoke(transform);
                GameObject obj = Instantiate(ParticleSys, transform.position, transform.rotation,
                GameObject.Find("Effect").transform);
                obj.GetComponent<ParticleSystem>().Play();
                Destroy(gameObject);
            }
        }
        else if (other.transform.name.Contains("Bounds"))
        {
            Destroy(gameObject);
        }
    }

}

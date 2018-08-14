using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;

[RequireComponent(typeof(EnemyMotionController))]
public class EnemySmall : MonoBehaviour {
    public delegate void SpawnEvent(GameObject _this);
    private GameObject BulletGroupHolder;
    public GameObject[] Bullets;
    private int frameCount;
    private int life = 15;

	// Use this for initialization
	void Start () 
    {
        // Debug.Log("Sending Message");
        // transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
		// OnInstantiate?.Invoke(gameObject);
        BulletGroupHolder = GameObject.FindGameObjectWithTag("BulletYellowSpreadHolder");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
		if (!(transform.localPosition.y <= -6.5)) // if reaches lower border, destroy itselft
        {
            if (transform.localPosition.y <= -0.4f)
            {
                SpawnBullet();
            }
        }    
	}

    void SpawnBullet()
    { 
        if (frameCount % 70 == 0) // every 30 frames spawn a bullet
        {
            {
                foreach(GameObject bullet in Bullets)
                {
                    if (BulletGroupHolder != null)
                    {
                        Instantiate(bullet, transform.position, bullet.transform.rotation, BulletGroupHolder.transform);
                    }
                }
            }
            
        }
        frameCount++;
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        life--;
        Debug.Log("Enemy collision enter!");
        if (life == 0)
        {
            Destroy(gameObject);
        }
    }

}

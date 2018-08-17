using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour 
{
    // [Header("子弹组Holder")]
    // public GameObject BulletGroupHolder;
    // [Header("子弹速度")]
    // public float BulletSpeed;
    // public GameObject Enemy;
    // public GameObject BulletSpawnPoint;
    // public GameObject BulletPrefab;
    public BulletMotionCfg BMCfg;
    private Vector3 ScreenBorder;
    private int FrameCount;
    private int DefaultFrameCount = 30;
    private int TotalSpawn = 0;
    private GameObject BulletMgr;
	// Use this for initialization
	void Start () 
    {
        // SpawnPoint = BMCfg.SpawnPoint;
        // TotalSpawn = BMCfg.TotalSpawn.Length;
		ScreenBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 5));
        BulletMgr = GameObject.FindGameObjectWithTag("BulletMgr");
        // foreach(var bullet in BulletPrefab.GetComponentsInChildren<BulletMotionController>())
        // {
        //     BulletGroup.Add(bullet.gameObject);
        // }
        // BulletMgr = GameObject.FindGameObjectWithTag("BulletMgr");
        // Debug.Log(ScreenBorder);
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        // create bullets
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
        if (FrameCount == DefaultFrameCount) // every 60 frames spawn a bullet
        {
            // Debug.Log(TotalSpawn);
            FrameCount = 0;
            // Debug.Log(TotalSpawn);
            if (TotalSpawn < BMCfg.TotalSpawn.Length)
            {
                // spawn point set to enemy
                if (BMCfg.TotalSpawn[TotalSpawn].SpawnPoint.Capacity == 0)
                {
                    foreach(Vector3 rotation in BMCfg.TotalSpawn[TotalSpawn].Rotation)
                    {
                        Instantiate(BMCfg.TotalSpawn[TotalSpawn].Appearence,
                        transform.position,
                        Quaternion.Euler(rotation),
                        BulletMgr.transform);
                    }
                }
                else
                {
                    foreach(Vector3 rotation in BMCfg.TotalSpawn[TotalSpawn].Rotation)
                    {
                        Instantiate(BMCfg.TotalSpawn[TotalSpawn].Appearence,
                        transform.position + BMCfg.TotalSpawn[TotalSpawn].SpawnPoint[0],
                        Quaternion.Euler(rotation),
                        BulletMgr.transform);
                    }
                }
                DefaultFrameCount = BMCfg.TotalSpawn[TotalSpawn].SpawnOffset;
            }
            else if (BMCfg.RepeatProcedure && TotalSpawn == BMCfg.TotalSpawn.Length)
            {
                // reset the spawn time    
                TotalSpawn = -1;
                FrameCount = DefaultFrameCount - 1;
            }
            TotalSpawn++;
        }
        FrameCount++;
    }
    // utils
}
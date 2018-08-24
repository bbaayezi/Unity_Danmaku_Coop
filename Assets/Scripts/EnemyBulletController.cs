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
    public BulletSpawnCfg BSCfg;
    private Vector3 ScreenBorder;
    private int FrameCount;
    private int TotalSpawn = 0;
    private GameObject BulletMgr;
	// Use this for initialization
	void Start () 
    {
		ScreenBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 5));
        BulletMgr = GameObject.FindGameObjectWithTag("BulletMgr");
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
        if (FrameCount == BSCfg.TotalSpawn[TotalSpawn].StartSpawnTime)
        {
            FrameCount = 0;
            if (TotalSpawn < BSCfg.TotalSpawn.Length)
            {
                // spawn point set to enemy
                if (BSCfg.TotalSpawn[TotalSpawn].SpawnPoint.Capacity == 0)
                {
                    foreach(Vector3 rotation in BSCfg.TotalSpawn[TotalSpawn].Rotation)
                    {
                        GameObject obj = Instantiate(BSCfg.TotalSpawn[TotalSpawn].Appearence,
                        transform.position,
                        Quaternion.Euler(rotation),
                        BulletMgr.transform);
                        BulletMotionController ctrlr = obj.GetComponent<BulletMotionController>();
                        ctrlr.HorVelocityTimeCurve = 
                        BSCfg.TotalSpawn[TotalSpawn].HorVelocityTimeCurve;
                        ctrlr.VerVelocityTimeCurve = 
                        BSCfg.TotalSpawn[TotalSpawn].VerVelocityTimeCurve;
                    }
                }
                else
                {
                    foreach(Vector3 rotation in BSCfg.TotalSpawn[TotalSpawn].Rotation)
                    {
                        GameObject obj = Instantiate(BSCfg.TotalSpawn[TotalSpawn].Appearence,
                        transform.position + BSCfg.TotalSpawn[TotalSpawn].SpawnPoint[0],
                        Quaternion.Euler(rotation),
                        BulletMgr.transform);
                        BulletMotionController ctrlr = obj.GetComponent<BulletMotionController>();
                        ctrlr.HorVelocityTimeCurve = 
                        BSCfg.TotalSpawn[TotalSpawn].HorVelocityTimeCurve;
                        ctrlr.VerVelocityTimeCurve = 
                        BSCfg.TotalSpawn[TotalSpawn].VerVelocityTimeCurve;
                    }
                }
                
                if (BSCfg.RepeatProcedure && TotalSpawn == BSCfg.TotalSpawn.Length - 1)
                {
                    // reset the spawn time    
                    TotalSpawn = -1;
                   
                }
            }
            TotalSpawn++;
            
        }
        FrameCount++;
    }
    // utils
}
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine;

public class EnemyMainController : MonoBehaviour
{
    public SpawnConfig[] Config;
    private int frameCount;
    private int Index = 0;
    public GameObject ParticleSys;
    private ParticleSystem Ps;

    private void Start() 
    {
        Ps = ParticleSys.GetComponent<ParticleSystem>();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        SpawnEnemy();
    }

    // private void OnEnable() 
    // {
    //     Enemy.OnDestroy += PlayDestroyEff;
    // }

    // private void OnDisable() 
    // {
    //     Enemy.OnDestroy -= PlayDestroyEff;
    // }

    // async void PlayDestroyEff(Transform trans)
    // {
    //     GameObject obj = Instantiate(ParticleSys, trans.position, transform.rotation);
    //     obj.GetComponent<ParticleSystem>().Play();
    //     await Task.Delay(TimeSpan.FromMilliseconds(1000));
    //     Destroy(obj);
    // }

    void SpawnEnemy()
    {
        frameCount++;
        if (Index < Config.Length && frameCount == Config[Index].StartSpawnTime)
        {
            frameCount = 0;
            SpawnConfig cfg = Config[Index];
            Index++;
            if (cfg.Enemy != null)
            {
                GameObject obj = Instantiate(cfg.Enemy, cfg.SpawnPoint.transform.position, cfg.Enemy.transform.rotation, transform.parent);
                // obj.AddComponent<EnemyMotionController>();
                obj.GetComponent<EnemyMotionController>().Cfg = cfg.EnemyMotionConfig;
                obj.GetComponent<EnemyBulletController>().BMCfg = cfg.BulletMotionConfig;
            }
        }
        else if (Index == Config.Length)
        {
            frameCount = 0;
            Debug.Log("Spawn Over!");
            Destroy(gameObject);
        }
    }
}
[System.Serializable]
public class SpawnConfig
{
    public int StartSpawnTime;
    public GameObject Enemy;
    public GameObject SpawnPoint;
    public EnemyMotionCfg EnemyMotionConfig;
    public BulletMotionCfg BulletMotionConfig;
    
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine;

public class EnemyMainController : MonoBehaviour
{
    public GameObject EnemySmall;
    public GameObject Parent;
    public GameObject[] SpawnPoints;

    private int frameCount;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // SpawnEnemy();
    }

    void SpawnEnemy()
    {
        frameCount++;
        if (frameCount == 180) // 3 seconds
        {
            frameCount = 0;
            if (EnemySmall != null)
            {
                Instantiate(EnemySmall, SpawnPoints[0].transform.position, EnemySmall.transform.rotation, Parent.transform);
            }
        }
    }
}

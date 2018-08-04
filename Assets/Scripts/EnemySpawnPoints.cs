using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour 
{
    public Dictionary<string, Transform> pointsDic = new Dictionary<string, Transform>();
    private GameObject[] points;
	// Use this for initialization
	void Start () 
    {
        Transform t;
        Transform[] transes = transform.GetComponentsInChildren<Transform>() as Transform[];

		foreach(Transform trans in transes)
        {
            pointsDic.Add(trans.name, trans);
            // Debug.Log(pointsDic.Count);
        }
        pointsDic.Remove("EnemySpawnPoints");
        pointsDic.TryGetValue("spawn_point_up", out t);
        // Debug.Log(t.position);
	}
	
	// Update is called once per frame
	void Update () 
    {

		
	}
}

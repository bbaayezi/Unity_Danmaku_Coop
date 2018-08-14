using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : MonoBehaviour 
{

	// Use this for initialization
    public float Speed;
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
		
        if (!(transform.localPosition.y <= -3))
        {
            transform.Translate(-Vector3.up * Speed * Time.fixedDeltaTime, Space.Self);
        }
	}
}

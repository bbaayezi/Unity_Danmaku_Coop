using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMotionController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate(-Vector3.up * .6f * Time.fixedDeltaTime, Space.Self);
	}
}

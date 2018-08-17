using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgePointController : MonoBehaviour 
{

	// Use this for initialization
	SpriteRenderer SRenderer;
	void Start () 
	{
		SRenderer = GetComponent<SpriteRenderer>();
		SRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SRenderer.enabled) Rotate();
	}

	void Rotate()
	{
		transform.rotation *= Quaternion.Euler(-Vector3.forward);
	}
}

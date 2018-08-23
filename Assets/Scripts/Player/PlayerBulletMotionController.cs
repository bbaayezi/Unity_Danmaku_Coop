using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMotionController : MonoBehaviour 
{

	// Use this for initialization
	private int FrameCount = 0;
	private SpriteRenderer SRenderer;
	void Start () 
	{
		SRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Shoot();
		if (transform.position.y > 4f)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.transform.name.Contains("enemy"))
		{
			Destroy(gameObject);
		}
	}

	void Shoot()
	{
		transform.Translate(-Vector2.left * 20f * Time.fixedDeltaTime);
	}
}

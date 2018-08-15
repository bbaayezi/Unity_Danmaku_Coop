using System.Collections;
using System.Collections.Generic;
using Project.Standard.Interface;
using System.Threading;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{

	// Use this for initialization
	private int frameCount = 0;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		frameCount++;
		if (frameCount == 3)
		{
			Shoot();
			frameCount = 0;
		}
	}

	public void Shoot()
	{
		transform.Translate(Vector2.up * 30f * Time.fixedDeltaTime, Space.World);
		if (transform.position.y >= 4.4f)
		{
			Destroy(gameObject);
		}
	}

	public void ClearBullets()
	{

	}
	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.name.Equals("Bounds"))
		{
			Destroy(gameObject);
		}
	}
}

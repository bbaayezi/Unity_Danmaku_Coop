using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmaku : MonoBehaviour
{
	public float speed;
	public virtual void Move() 
	{
		transform.Translate(-Vector2.up * speed * Time.deltaTime);
		if (transform.position.x > 5f || transform.position.x < -5f
		|| transform.position.y > 6f || transform.position.y < -6f)
		{
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
}

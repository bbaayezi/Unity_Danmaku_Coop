using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [RequireComponent(typeof(Collider2D))]
public class BulletMotionController : MonoBehaviour 
{

	// Use this for initialization
	private SpriteRenderer SRenderer;
	private int Transition = 5;
	private int frameCount;
	private float InitOpacity = .5f;
	public BulletMotionCfg BMCfg;
	public AnimationCurve HorVelocityTimeCurve;
	public AnimationCurve VerVelocityTimeCurve;
	private float CurrentTime;
	private float _Speed;
	private Vector2 Movement;
	void Start () 
	{
		// SpawnPoint = BulletMotionConfig.SpawnPoint;
		BeforeCreated();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		frameCount++;
		if (!DuringCreation())
		{
			if (CurrentTime == Mathf.Infinity - 0.1f)
			{
				CurrentTime = 0;
			}
			Movement = new Vector2(HorVelocityTimeCurve.Evaluate(CurrentTime),
			VerVelocityTimeCurve.Evaluate(CurrentTime));
			// Debug.Log("Not During Creation");
			transform.Translate(Movement * Time.fixedDeltaTime, Space.Self);
			if (transform.position.y < -2f || transform.position.x > 2.5f || transform.position.x < -3.5f)
			{
				Destroy(gameObject);
			}
			CurrentTime += 0.01f;
		}
	}

	void BeforeCreated()
	{
		SRenderer = GetComponent<SpriteRenderer>();
		transform.localScale = new Vector3(2, 2, 2);
		SRenderer.material.color = new Color(1, 1, 1, InitOpacity);
	}

	bool DuringCreation()
	{
		if (Transition != 0)
		{
			Transition--;
			InitOpacity += .1f;
			transform.localScale -= new Vector3(.2f, .2f, .2f);
			SRenderer.material.color = new Color(1, 1, 1, InitOpacity);
			return true;
		}
		return false;
	}

	void DoBulletMotion()
	{

	}
}

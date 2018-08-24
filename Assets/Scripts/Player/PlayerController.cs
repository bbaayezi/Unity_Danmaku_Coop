using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	private float HorInput;
	private float VerInput;
	private float Speed = 2.8f;
	private Vector2 HorMovement = Vector2.zero;
	private Vector2 VerMovement = Vector2.zero;
	private Vector2 Movement;
	private GameObject SlowEffect;
	private int FrameCount = 0;
	private SpriteRenderer BulletSRenderer;

	//
	public int Level;
	public GameObject Wingman;
	public GameObject Bullet;
	private Animator anim;
	
	// Use this for initialization
	void Start () 
	{
		SlowEffect = GetComponentInChildren<JudgePointController>().gameObject;
		BulletSRenderer = Bullet.GetComponent<SpriteRenderer>();
		if (Level > 10)
		{
			SpawnWingman(transform.position - new Vector3(0.18f, 0.22f, 0),
			transform.position + new Vector3(0.18f, -0.22f, 0));
		}
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		FrameCount++;
		HorInput = Input.GetAxis("Horizontal");
		VerInput = Input.GetAxis("Vertical");
		Move();
		
		if (FrameCount == 3)
		{
			FrameCount = 0;
			// spawn normal bullet
			// BulletSRenderer.enabled = true;

			// if press Z
			if (Input.GetAxis("Shoot") > .1f)
			{
				SpawnBullet(transform.position + new Vector3(-0.2f, 0.008f, 0),
				transform.position + new Vector3(0.2f, 0.008f, 0));
			}
		}
	}

	void Move()
	{
		// check for regular movement
		if (!Idle(HorInput) && Idle(VerInput))
		{
			HorMovement = Mathf.Sign(HorInput) * -Vector2.left * Speed * Time.fixedDeltaTime;
			VerMovement = Vector2.zero;
		}
		else if (Idle(HorInput) && !Idle(VerInput))
		{
			HorMovement = Vector2.zero;
			VerMovement = Mathf.Sign(VerInput) * Vector2.up * Speed * Time.fixedDeltaTime;
		}
		else if (!Idle(HorInput) && !Idle(VerInput))
		{
			HorMovement = Mathf.Sign(HorInput) * -Vector2.left * Speed * Time.fixedDeltaTime / Mathf.Sqrt(2.0f);
			VerMovement = Mathf.Sign(VerInput) * Vector2.up * Speed * Time.fixedDeltaTime / Mathf.Sqrt(2.0f);
		}
		else
		{
			ResetMovement();
		}
		// check for low speed
		if (Input.GetKey(KeyCode.LeftShift))
		{
			Speed = 1.4f;
			SlowEffect.GetComponent<SpriteRenderer>().enabled = true;
		}
		else
		{
			Speed = 2.8f;
			SlowEffect.GetComponent<SpriteRenderer>().enabled = false;
		}
		// check for border

		if (transform.localPosition.x > 2.08f)
		{
			if (HorInput > 0)
			{
				HorMovement = Vector2.zero;
			}
		}
		if (transform.localPosition.x < -2.11f)
		{
			if (HorInput < 0)
			{
				HorMovement = Vector2.zero;
			}
		}
		if (transform.localPosition.y > 3.65f)
		{
			if (VerInput > 0)
			{
				VerMovement = Vector2.zero;
			}
		}
		if (transform.localPosition.y < -1.71f)
		{
			if (VerInput < 0)
			{
				VerMovement = Vector2.zero;
			}
		}
		// update movement
		
		Movement = HorMovement + VerMovement;
		if (Movement.x > 0.01f)
		{
			anim.SetBool("TurnRight", true);
			anim.SetBool("TurnLeft", false);
		}
		else if (Movement.x < -0.01f)
		{
			anim.SetBool("TurnLeft", true);
			anim.SetBool("TurnRight", false);
		}
		transform.Translate(Movement, Space.Self);
	}

	void SpawnWingman(params Vector3[] position)
	{
		foreach(Vector3 pos in position)
		{
			Instantiate(Wingman, pos, Wingman.transform.rotation, transform);
		}
	}

	void SpawnBullet(params Vector3[] position)
	{
		foreach(Vector3 pos in position)
		{
			Instantiate(Bullet, pos, Bullet.transform.rotation, transform.parent);
		}
	}

	private bool Idle(float input)
	{
		return (input < .1f && input > -.1f) ? true : false;
	}

	private void ResetMovement()
	{
		HorMovement = VerMovement = Vector2.zero;
	}

	private void OnCollisionEnter2D(Collision2D other) 
	{
		Debug.Log("Get hit! " + other.gameObject.name);
	}
}

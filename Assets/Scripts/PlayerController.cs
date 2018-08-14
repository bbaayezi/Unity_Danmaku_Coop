using System.Collections;
using System.Collections.Generic;
using Project.Standard.Interface;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerControl
{

	private GameObject m_Player;
	private Animator anim;
	private GameObject m_SlowEff;
	private float m_HorInput;
	private float m_VerInput;
	private float m_MoveSpeed = 1.9f;
	private int m_Bombs = 2;
	private GameObject[] m_Otaku;
	// Use this for initialization
	void Start () 
	{
		// get the player object
		m_Player = GameObject.FindGameObjectWithTag("Player0");
		m_SlowEff = GameObject.FindGameObjectWithTag("SlowEffect");
		m_Otaku = GameObject.FindGameObjectsWithTag("Otaku");

		anim = GameObject.FindObjectOfType<Animator>();
		// Debug.Log(m_Player);
	}
	
	// use FixedUpdate for kinemic
	private void FixedUpdate() 
	{
		// Move
		Move();
	}

	// implementation
	public void Move()
	{
		// Get the axis input value during every update
		m_HorInput = Input.GetAxis("Horizontal");
		m_VerInput = Input.GetAxis("Vertical");

		RotateOtaku();

		Vector3 movement = Vector3.zero;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			m_MoveSpeed = .8f;
			m_SlowEff.GetComponent<SpriteRenderer>().enabled = true;
			RotateSlowEff();
		}
		else
		{
			m_MoveSpeed = 1.9f;
			m_SlowEff.GetComponent<SpriteRenderer>().enabled = false;
		}

		if (m_VerInput < .1f && m_VerInput > -.1f)
		{
			if (m_HorInput < -.1f)
			{
				if (anim != null)
				{
					ResetAnimator();
					anim.SetBool("MoveLeft", true);
				}	
				movement = m_MoveSpeed * Time.fixedDeltaTime * -Vector3.right;
			}
				
			else if (m_HorInput > .1f)
			{
				if (anim != null)
				{
					ResetAnimator();
					anim.SetBool("MoveRight", true);
				}
				movement = m_MoveSpeed * Time.fixedDeltaTime * Vector3.right;
			}
				
		}
		else if (m_HorInput < .1f && m_HorInput > -.1f)
		{
			if (anim != null) ResetAnimator();
			if (m_VerInput <-.1f)
				movement = m_MoveSpeed * Time.fixedDeltaTime * -Vector3.up;
			else if (m_VerInput > .1f)
				movement = m_MoveSpeed * Time.fixedDeltaTime * Vector3.up;
				
		}
		else
		{
			m_MoveSpeed /= 1.414f;
			if (m_HorInput > 0.1f && m_VerInput > 0.1f)
			{
				if (anim != null)
				{
					ResetAnimator();
					anim.SetBool("MoveRight", true);
				}	
				movement = (transform.right + transform.up) * m_MoveSpeed * Time.fixedDeltaTime;
			}
			else if (m_HorInput > 0.1f && m_VerInput < -0.1f)
			{
				if (anim != null)
				{
					ResetAnimator();
					anim.SetBool("MoveRight", true);
				}	
				movement = (transform.right - transform.up) * m_MoveSpeed * Time.fixedDeltaTime;
			}
			else if (m_HorInput < -0.1f && m_VerInput > 0.1f)
			{
				if (anim != null)
				{
					ResetAnimator();
					anim.SetBool("MoveLeft", true);
				}	
				movement = (transform.up - transform.right) * m_MoveSpeed * Time.fixedDeltaTime;
			}
			else if (m_HorInput < -0.1f && m_VerInput < -0.1f)
			{
				if (anim != null)
				{
					ResetAnimator();
					anim.SetBool("MoveLeft", true);
				}	
				movement = (-transform.up - transform.right) * m_MoveSpeed * Time.fixedDeltaTime;
			}
		}

		if (m_HorInput > -.1f && m_HorInput < .1f && m_VerInput > -.1f && m_VerInput < .1f)
			if (anim != null) ResetAnimator();
		

		// vertical offset
		// movement += m_MoveSpeed * Time.fixedDeltaTime * Vector3.up;

		m_Player.transform.position += movement;
	}

	// Deprecated
	public void ApplyShoot()
	{

	}

	public bool UseBomb()
	{
		return m_Bombs == 0 ? false : true;
	}

	public void SwitchToLowSpeed()
	{

	}

	// utils
	private void ResetAnimator()
	{
		anim.SetBool("MoveLeft", false);
		anim.SetBool("MoveRight", false);
	}

	private void RotateSlowEff()
	{
		m_SlowEff.transform.rotation *= Quaternion.Euler(0, 0, -1.2f);
	}

	private void RotateOtaku()
	{
		foreach(GameObject o in m_Otaku)
		{
			o.transform.rotation *= Quaternion.Euler(0, 0, -4f);
		}
	}

	private void FocusOtaku()
	{

	}
	
}

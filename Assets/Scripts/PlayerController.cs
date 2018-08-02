using System.Collections;
using System.Collections.Generic;
using Project.Standard.Interface;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerControl
{

	private GameObject m_Player;
	private float m_HorInput;
	private float m_VerInput;
	private float m_MoveSpeed = 2.5f;
	// Use this for initialization
	void Start () 
	{
		// get the player object
		m_Player = GameObject.FindGameObjectWithTag("Player0");
		Debug.Log(m_Player);
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

		Vector3 movement = Vector3.zero;

		if (m_VerInput < .1f && m_VerInput > -.1f)
		{
			if (m_HorInput < -.1f)
				movement = m_MoveSpeed * Time.fixedDeltaTime * -Vector3.right;
			else if (m_HorInput > .1f)
				movement = m_MoveSpeed * Time.fixedDeltaTime * Vector3.right;
		}
		else if (m_HorInput < .1f && m_HorInput > -.1f)
		{
			if (m_VerInput <-.1f)
				movement = m_MoveSpeed * Time.fixedDeltaTime * -Vector3.up;
			else if (m_VerInput > .1f)
				movement = m_MoveSpeed * Time.fixedDeltaTime * Vector3.up;
		}
		else
		{
			if (m_HorInput > 0.1f && m_VerInput > 0.1f)
			{
				movement = (transform.right + transform.up) * m_MoveSpeed * Time.fixedDeltaTime;
			}
			else if (m_HorInput > 0.1f && m_VerInput < -0.1f)
			{
				movement = (transform.right - transform.up) * m_MoveSpeed * Time.fixedDeltaTime;
			}
			else if (m_HorInput < -0.1f && m_VerInput > 0.1f)
			{
				movement = (transform.up - transform.right) * m_MoveSpeed * Time.fixedDeltaTime;
			}
			else if (m_HorInput < -0.1f && m_VerInput < -0.1f)
			{
				movement = (-transform.up - transform.right) * m_MoveSpeed * Time.fixedDeltaTime;
			}
		}
		

		// vertical offset
		// movement += m_MoveSpeed * Time.fixedDeltaTime * Vector3.up;

		m_Player.transform.position += movement;
	}

	public void ApplyShoot()
	{

	}

	public bool UseBomb()
	{
		return true;
	}

	public void SwitchToLowSpeed()
	{

	}
}

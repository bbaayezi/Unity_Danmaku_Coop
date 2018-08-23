using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class EnemyMotionController : MonoBehaviour 
{
	public EnemyMotionCfg Cfg;
	[Header("是否使用预设值")]
	// [HideInInspector]
	public bool UsePresets;
	private GameObject Self;
	// private static EnemyMotionCfg Cfg;
	private float TotalTime;
	private float CurrentTime = 0;
	private Vector2 Movement;
	// Use this for initialization
	void Start () 
	{
		Self = transform.gameObject;
		TotalTime = Mathf.Max(
			Cfg.VerVelocity_TimeCurve.keys[Cfg.VerVelocity_TimeCurve.length - 1].time,
			Cfg.HorVelocity_TimeCurve.keys[Cfg.HorVelocity_TimeCurve.length - 1].time
		);
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		DoMotion();
	}
	void DoMotion()
	{
		if (Cfg != null)
		{
			switch ((int)Cfg.CurveType)
			{
				// VT Curve
				case 0:
					DoVTMotion();
				break;
				// AT Curve
				case 1:
					DoATMotion();
				break;
			}
		}
	}
	// utils
	void DoVTMotion()
	{
		if (CurrentTime < Mathf.Infinity - 0.01f)
		{
			Movement = new Vector2(Cfg.HorVelocity_TimeCurve.Evaluate(CurrentTime),
			Cfg.VerVelocity_TimeCurve.Evaluate(CurrentTime));
			transform.Translate(Movement * Time.fixedDeltaTime);
			CurrentTime += 0.01f;
		}
		else
		{
			CurrentTime = 0;
			Destroy(gameObject);
		}
	}
	void DoATMotion()
	{
		
	}
}



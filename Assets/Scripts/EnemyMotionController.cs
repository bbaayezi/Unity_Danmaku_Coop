using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class EnemyMotionController : MonoBehaviour 
{
	public struct Config
	{
		[Header("参考标准速度：0.6")]
		public Vector2 Speed;
		[Header("衰减速度(加速度)每秒衰减一次")]
		public Vector2 FadeSpeed;
		[Header("速度衰减限制(达到限制后速度不再衰减)")]
		public Vector2 LimitFadeSpeed;
	}
	private int frameCount;
	[Header("是否使用预设值")]
	// [HideInInspector]
	public bool UsePresets;
	[Header("预设值1：向下匀速运动")]
	public bool Pre1;
	[Header("预设值2：向右匀速运动")]
	public bool Pre2;
	[Header("预设值3：向左匀速运动")]
	public bool Pre3;
	[Header("预设值4：以屏幕中心为中点，开口向上抛物线运动")]
	public bool Pre4;
	// [Header("参考标准速度：0.6")]
	private Vector2 Speed;
	// [Header("衰减速度(加速度)每秒衰减一次")]
	private Vector2 FadeSpeed;
	// [Header("速度衰减限制(达到限制后速度不再衰减)")]
	private Vector2 LimitFadeSpeed;
	[Range(1, 10), Header("设置动作片段次数(右键点击Auto Set Config自动生成配置数组)"), 
	ContextMenuItem("Auto Set Config", "AutoSet")]
	public int MotionClips;
	
	public MotionConfigs[] MotionConfigs;

	private GameObject Self;
	private float _HorizontalSpeed;
	private float _VerticalSpeed;

	// Use this for initialization
	void Start () 
	{
		Self = transform.gameObject;
		if (UsePresets)
		{
			if (Pre1)
			{
				_HorizontalSpeed = 0;
				_VerticalSpeed = -.6f;
			}
			else if (Pre2)
			{
				_HorizontalSpeed = -.6f;
				_VerticalSpeed = 0;
			}
		}
		else
		{
			Speed = MotionConfigs[0].Speed;
			FadeSpeed = MotionConfigs[0].FadeSpeed;
			LimitFadeSpeed = MotionConfigs[0].LimitFadeSpeed;
			//
			_HorizontalSpeed = Speed.x;
			_VerticalSpeed = Speed.y;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		DoMotion();
	}
	void DoMotion()
	{
		frameCount++;
		if (!(transform.localPosition.y <= -6.5))
		{
			transform.Translate(Vector3.up * _VerticalSpeed * Time.fixedDeltaTime, Space.Self);
			transform.Translate(Vector2.left * _HorizontalSpeed * Time.fixedDeltaTime, Space.Self);
			// fading
			if (frameCount % 20 == 0)
			{
				_HorizontalSpeed += FadeSpeed.x;
				_VerticalSpeed += FadeSpeed.y;
				// check the limit
				if (LimitFadeSpeed != Vector2.zero && frameCount == 60)
				{
					if (_HorizontalSpeed > LimitFadeSpeed.x - 0.01f
						&& _HorizontalSpeed < LimitFadeSpeed.x + 0.01f) FadeSpeed.x = 0;
					if (_VerticalSpeed > LimitFadeSpeed.y - 0.01f
						&& _VerticalSpeed < LimitFadeSpeed.y + 0.01f) FadeSpeed.y = 0;
					// Debug.Log($"{FadeSpeed}, {_VerticalSpeed}, {LimitFadeSpeed}");
					frameCount = 0;
				}
				// update Speed
				
			}
			
		}
		else
		{
			Destroy(Self);
		}
	}
	// utils
	void AutoSet()
	{
		MotionConfigs = new MotionConfigs[MotionClips];
	}
}

[Serializable]
public class MotionConfigs
{
	[Header("参考标准速度：0.6")]
	public Vector2 Speed;
	[Header("衰减速度（加速度）每秒衰减一次")]
	public Vector2 FadeSpeed;
	[Header("速度衰减限制（达到限制后速度不再衰减）")]
	public Vector2 LimitFadeSpeed;
	[Header("此动作片段与下一个动作片段的间隔时间")]
	public int OffsetTime;
}


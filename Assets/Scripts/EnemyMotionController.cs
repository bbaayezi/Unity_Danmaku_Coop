using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class EnemyMotionController : MonoBehaviour 
{
	[Serializable]
	public enum EMotionPresets
	{
		LinearUp,
		LinearDown,
		LinearLeft,
		LinearRight
	}
	
	private int frameCount;
	public EnemyMotionCfg MotionClipsAssets;
	[Header("是否使用预设值")]
	// [HideInInspector]
	public bool UsePresets;
	[Header("预设值选择")]
	public EMotionPresets Presets;
	// [Header("参考标准速度：0.6")]
	private Vector2 Speed;
	// [Header("衰减速度(加速度)每秒衰减一次")]
	private Vector2 FadeSpeed;
	// [Header("速度衰减限制(达到限制后速度不再衰减)")]
	private Vector2 LimitFadeSpeed;
	[Range(1, 10), Header("设置动作片段次数(右键点击Auto Set Config自动生成配置数组)"), 
	ContextMenuItem("Auto Set Config", "AutoSet")]
	public int MotionClips;
	
	// public MotionConfigs[] MotionConfigs;

	private GameObject Self;
	private float _HorizontalSpeed;
	private float _VerticalSpeed;
	private static EnemyMotionCfg Cfg;
	private MotionConfig[] Configs;
	private int ClipCount = 0;
	private int AwaitFrameCount;
	private bool WaitForNextCLip = false;
	// Use this for initialization
	void Start () 
	{
		Self = transform.gameObject;
		// string path = $"{Application.dataPath}/Scripts/Utils/EnemyMotionPreset1.asset";
		
		// Debug.Log(Cfg.Speed);
		if (UsePresets)
		{
			// if (Pre1)
			// {
			// 	_HorizontalSpeed = 0;
			// 	_VerticalSpeed = -.6f;
			// }
			// else if (Pre2)
			// {
			// 	_HorizontalSpeed = -.6f;
			// 	_VerticalSpeed = 0;
			// }
			//
			Debug.Log(Presets);
			switch((int)Presets)
			{
				case (int)EMotionPresets.LinearUp:
					Debug.Log("Up");
				break;
				case (int)EMotionPresets.LinearDown:
					// if (Configs.Length == 1)
					// {
					// 	Speed = Configs[0].Speed;
					// 	FadeSpeed = Configs[0].FadeSpeed;
					// 	LimitFadeSpeed = Configs[0].LimitFadeSpeed;
					// }
					Speed = new Vector2(0, -0.6f);
					FadeSpeed = Vector2.zero;
					LimitFadeSpeed = Vector2.zero;
					// Debug.Log($"{Speed}, {FadeSpeed}");
				break;
			}
		}
		else
		{
			Cfg = MotionClipsAssets;
			Configs = Cfg.Configs;
			// initialize
			// Speed = Configs[0].Speed;
			// FadeSpeed = Configs[0].FadeSpeed;
			// LimitFadeSpeed = Configs[0].LimitFadeSpeed;
			//
		}
		_HorizontalSpeed = Speed.x;
		_VerticalSpeed = Speed.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		DoMotion();
	}
	void DoMotion()
	{
		// Debug.Log(WaitForNextCLip + ", " + ClipCount + ", " + Configs.Length);
		// Test field
		if (Configs.Length > 1 && ClipCount != Configs.Length && !WaitForNextCLip)
		{
			// Debug.Log("Change!");
			Speed = Configs[ClipCount].Speed;
			FadeSpeed = Configs[ClipCount].FadeSpeed;
			LimitFadeSpeed = Configs[ClipCount].LimitFadeSpeed;
			//
			_HorizontalSpeed = Speed.x;
			_VerticalSpeed = Speed.y;
			//
			AwaitFrameCount = Configs[ClipCount].OffsetTime * 60;
			WaitForNextCLip = true;
			ClipCount++;
		}
		else if (Configs.Length == 1)
		{
			Speed = Configs[ClipCount].Speed;
			FadeSpeed = Configs[ClipCount].FadeSpeed;
			LimitFadeSpeed = Configs[ClipCount].LimitFadeSpeed;
			_HorizontalSpeed = Speed.x;
			_VerticalSpeed = Speed.y;
		}
		//
		frameCount++;
		if (!(transform.localPosition.y <= -6.5))
		{
			transform.Translate(Vector3.up * _VerticalSpeed * Time.fixedDeltaTime, Space.Self);
			transform.Translate(Vector2.left * _HorizontalSpeed * Time.fixedDeltaTime, Space.Self);
			// Debug.Log($"{_HorizontalSpeed}, {_VerticalSpeed}");
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
					frameCount = 0;
					
				}
				// update Speed
			}

			// wait for next clip
			if (_HorizontalSpeed > LimitFadeSpeed.x - 0.01f
				&& _HorizontalSpeed < LimitFadeSpeed.x + 0.01f
				&& _VerticalSpeed > LimitFadeSpeed.y - 0.01f
				&& _VerticalSpeed < LimitFadeSpeed.y + 0.01f
				)
			{
				FadeSpeed = Vector2.zero;
				// Debug.Log("Equals!"+AwaitFrameCount);
				AwaitFrameCount--;
				if (AwaitFrameCount >= -1 && AwaitFrameCount <= 0) WaitForNextCLip = false;
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
		// MotionConfigs = new MotionConfigs[MotionClips];
	}
}



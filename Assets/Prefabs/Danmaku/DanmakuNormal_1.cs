using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuNormal_1 : MonoBehaviour 
{
	private List<Danmaku> _danmakuList;
	private float _baseSpeed = 0.8f;
	// Use this for initialization
	void Start () 
	{
		_danmakuList = new List<Danmaku>(GetComponentsInChildren<Danmaku>());
		foreach(Danmaku obj in _danmakuList)
		{
			obj.speed = _baseSpeed;
			_baseSpeed += 0.1f;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(Danmaku obj in _danmakuList)
		{
			if (obj != null)
			obj.Move();
		}
	}
}

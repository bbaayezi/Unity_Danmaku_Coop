using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuNormal_2 : MonoBehaviour 
{
	public GameObject SpawnObj;
	public int spawnNum;
	public int spawnOffset;
	public int rotationOffset;
	public float rotationPerSpawn;
	private List<Danmaku> _danmakuList;
	private int _frame;
	// Use this for initialization
	void Start () 
	{
		_danmakuList = new List<Danmaku>(GetComponentsInChildren<Danmaku>());
		foreach(Danmaku obj in _danmakuList)
		{
			obj.speed = 1.2f;
		}
		// rotationOffset = 360 / spawnNum;
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(Danmaku obj in GetComponentsInChildren<Danmaku>())
		{
			obj.Move();
		}
	}
}

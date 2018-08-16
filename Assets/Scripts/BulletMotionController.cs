using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [RequireComponent(typeof(Collider2D))]
public class BulletMotionController : MonoBehaviour 
{

	// Use this for initialization
	[Header("子弹生成的间隔时间")]
	public int SpawnOffset;
	[Header("绑定的敌机目标")]
	public GameObject BindedEnemyTarget;
	private SpriteRenderer SRenderer;
	private int Transition = 5;
	private int frameCount;
	private float InitOpacity = .5f;
	void Start () 
	{
		BeforeCreated();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		frameCount++;
		if (frameCount == SpawnOffset * 60)
		{
			frameCount = 0;
			Instantiate(gameObject, BindedEnemyTarget.transform.position, transform.rotation);
		}
		if (!DuringCreated())
		{
			// Debug.Log("Not During Creation");
			transform.Translate(-Vector3.up * 1.2f * Time.fixedDeltaTime, Space.Self);
		}
	}

	void BeforeCreated()
	{
		SRenderer = GetComponent<SpriteRenderer>();
		transform.localScale = new Vector3(2, 2, 2);
		SRenderer.material.color = new Color(1, 1, 1, InitOpacity);
	}

	bool DuringCreated()
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
}

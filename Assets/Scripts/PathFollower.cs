using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour 
{
	private Node[] pathNodes;
	public GameObject Enemy;
	public float Speed;
	static Vector3 currentPosition;
	static Vector3 initPosition;
	private float timer;
	int currentNode = 0;
	public delegate void PathFollowEvent();
	public static event PathFollowEvent OnBulletSpawnPoint;
	// Use this for initialization
	void Start () 
	{
		pathNodes = GetComponentsInChildren<Node>();
		CheckNode();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		timer += Speed * Time.fixedDeltaTime;
		try
		{
			if (Enemy.transform.position != currentPosition)
			{
				Enemy.transform.position = Vector3.Lerp(initPosition, currentPosition, timer);
			}
			else
			{
				if (currentNode < pathNodes.Length - 1)
				{
					currentNode++;
					CheckNode();
				}
			}
		}
		catch(MissingReferenceException e)
		{
			Debug.Log("Null gameobject.\n" + e.StackTrace);
			// Enemy = null;
		}
	}

	void CheckNode()
	{
		initPosition = Enemy.transform.position;
		timer = 0;
		currentPosition = pathNodes[currentNode].transform.position;
		// check for bullet spawn point
		if (pathNodes[currentNode].name.Contains("Node_BulletSpawn"))
		{
			OnBulletSpawnPoint?.Invoke();
		}
	}
}

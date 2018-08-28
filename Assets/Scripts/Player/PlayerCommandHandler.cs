using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommandHandler : MonoBehaviour, ICommandable
{
	private float _speed;
	public void Move(Vector2 movement)
	{
		Debug.Log("Player Move!" + movement);
	}

	public void Shoot()
	{
		Debug.Log("Player Shoot!");
	}

	private void OnGUI() 
	{
		GUI.Box (new Rect (0,Screen.height - 100,200,100), "Bottom-left");
		_speed = GUI.HorizontalSlider(new Rect (25, 25, 100, 30), _speed, 0f, 10f);
	}
}

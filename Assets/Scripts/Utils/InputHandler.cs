using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler 
{
	bool IsPressed(string axisName, out float axisValue)
	{
		float input = Input.GetAxis(axisName);
		if (input > 0.01f || input < -0.01f)
		{
			axisValue = input;
			return true;
		}
		else
		{
			axisValue = 0;
			return false;
		}
	}

	public Command HandleInput()
	{
		float horVal;
		float verVal;
		float shootVal;
		if (IsPressed("Horizontal", out horVal) && IsPressed("Vertical", out verVal))
		{
			MoveCommand move = new MoveCommand();
			move.Movement = new Vector2(horVal, verVal);
			return move;
		}
		else if (IsPressed("Shoot", out shootVal))
		{
			return new ShootCommand();
		}
		return null;
	}
}

public class ShootCommand : Command
{
	public override void Execute<T>(GameObject gameObject)
	{
		gameObject.GetComponent<T>().Shoot();
	}
}

public class MoveCommand : Command
{
	public Vector2 Movement { get; set; }
	public override void Execute<T>(GameObject gameObject)
	{
		gameObject.GetComponent<T>().Move(Movement);
	}
}

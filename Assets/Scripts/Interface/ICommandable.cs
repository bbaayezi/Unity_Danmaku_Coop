using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICommandable
{
	void Shoot();
	void Move(Vector2 Movement);
}

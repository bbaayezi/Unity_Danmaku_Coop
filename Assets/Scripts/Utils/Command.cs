using UnityEngine;
using System.Collections.Generic;
public abstract class Command 
{
	public abstract void Execute<T>(GameObject gameObject) where T : ICommandable;
}

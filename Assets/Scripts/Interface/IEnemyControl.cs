using System.Collections;
using System.Collections.Generic;

public interface IEnemyControl
{
	// as enemy is doing motion passively
	// we call it DoMotionClip rather than Move
	void DoMotionClip();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Standard.Interface
{
	// This interface is used to limit the function of bullet controller
	public interface IBulletControl
	{
		// After the bullet have spawned
		// First thing is to shoot
		// Updates every frame
		/// <param name="shootingSpeed">Determin the bullet speed</param>
		void Shoot(GameObject newBullet);

		// Next it is necessary to clear the bullets
		// Usually when off screen
		// Also when collide with other object
		// Also when bombs occured

		void ClearBullets();
	}
}
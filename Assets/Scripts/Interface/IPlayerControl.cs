using System.Collections;
using System.Collections.Generic;

namespace Project.Standard.Interface
{
	interface IPlayerControl
	{
		// This interface limits the control of player

		// Player can react to key press and move
		void Move();
		// When press shoot button, player can shoot
		void ApplyShoot();
		// When press bomb button, player can use bomb
		// Return a bool value, as there exist two status of using bombs
		// true stands that there is at least 1 bomb remaining for player
		// flase stands that therr is no bomb remaining
		bool UseBomb();
		// When the player use low speed mode
		void SwitchToLowSpeed();
	}
}

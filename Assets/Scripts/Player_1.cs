﻿using System.Collections;
using System.Collections.Generic;
using Project.Standard.Abstract;
using UnityEngine;

public class Player_1 : Player
{
	private int _playerId;
	// Default number of life
	private int _life = 3;
	private int _bombs = 2;
	private bool _isAlive = true;
	// Attributes
	public int Life
	{
		get { return _life; }
		set{ _life = value; }
	}
		public int Bombs
	{
		get { return _bombs; }
		set { _bombs = value; }
	}
	public bool IsAlive
	{
		get { return _isAlive; }
		set { _isAlive = value; }
	}
}
using UnityEngine;
using System.Collections;

using Iwana.Wire;
using Iwana.Events;

public class PlayerWire : IIwWire 
{
	public const string NAME = "";
	public const string PLAYER_LIVES_CHANGED = "player_lives_changed";

	private IwEventDispatcher _dispatcher = null;
	private int _lives = 9;

	public PlayerWire ()
	{}

	public int lives 
	{ 
		get { return _lives; } 
		set { _lives = value; _dispatcher.triggerEvent ( new IwEvent ( PLAYER_LIVES_CHANGED ) ); } 
	}

	public string name { get { return NAME; } }
	public IwEventDispatcher dispatcher { get { return _dispatcher; } set { _dispatcher = value; } }
	public void initialize ()
	{}

	public void dispose ()
	{}
}

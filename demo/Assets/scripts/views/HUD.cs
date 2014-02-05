using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Iwana.View;
using Iwana.Events;

public class HUD : MonoBehaviour, IIwView
{
	private IwEventDispatcher _dispatcher = null;
	private Rect _textArea = new Rect(10,0,Screen.width, 20);
	private int _livesToShow = 9;

	// Use this for initialization
	void Start () 
	{
		IwGameDemo.Instance.addView (this);
	}

	void OnGUI ()
	{
		GUI.Label (new Rect (Screen.width/2, 0, Screen.width/2, 20), "INSTRUCTIONS: A -> Alert enemies, X -> Player is safe, E -> Player loses 1 life");
		GUI.Label (_textArea, "PLAYER LIVES: " + _livesToShow );
	}

	public void	initialize ()
	{}
	
	public void dispose ()
	{}

	public void notify ( IIwEvent evt )
	{
		if ( evt.name == PlayerWire.PLAYER_LIVES_CHANGED )
		{
			PlayerWire playerData = IwGameDemo.Instance.getWire ( PlayerWire.NAME ) as PlayerWire;
			_livesToShow = playerData.lives;
		}
	}

	public string name 
	{ 
		set { gameObject.name = value;}
		get { return gameObject.name; } 
	}
	
	public IwEventDispatcher dispatcher { set { _dispatcher = value; } get { return _dispatcher; } }
	public List<string>  eventsToHand { get { return new List<string>{PlayerWire.PLAYER_LIVES_CHANGED}; } }
}

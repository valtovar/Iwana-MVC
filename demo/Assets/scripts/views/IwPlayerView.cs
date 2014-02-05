using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Iwana.View;
using Iwana.Events;

public class IwPlayerView : MonoBehaviour, IIwView 
{
	private IwEventDispatcher _dispatcher = null;
	public const string PLAYER_WRONG = "player_wrong";
	public const string PLAYER_IS_SAFE = "player_is_safe";
	public const string PLAYER_LOSES_LIFE = "player_loses_life";

	// Use this for initialization
	void Start () 
	{
		IwGameDemo.Instance.addView (this);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( Input.GetKeyDown ( KeyCode.A ) )
		{
			// event dispatched when the player is in danger.
			_dispatcher.triggerEvent ( new IwEvent ( PLAYER_WRONG ) );
		}
		else if ( Input.GetKeyDown ( KeyCode.X ) )
		{
			// event dispatched when the player is safe.
			_dispatcher.triggerEvent ( new IwEvent ( PLAYER_IS_SAFE ) );
		}
		else if ( Input.GetKeyDown ( KeyCode.E ) )
		{
			// event dispatched when the player loses 1 life.
			_dispatcher.triggerEvent ( new IwEvent ( PLAYER_LOSES_LIFE ) );
		}
	}

	public void	initialize ()
	{}

	public void dispose ()
	{}

	public void notify ( IIwEvent evt )
	{}
	
	public string name 
	{ 
		set { gameObject.name = value;}
		get { return gameObject.name; } 
	}

	public IwEventDispatcher dispatcher { set { _dispatcher = value; } get { return _dispatcher; } }
	public List<string>  eventsToHand { get { return null; } }
}

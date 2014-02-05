using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Iwana.View;
using Iwana.Events;

public class IwEnemyView : MonoBehaviour, IIwView 
{
	private IwEventDispatcher _dispatcher = null;
	private bool _inAttack = false;

	// Use this for initialization
	void Start () 
	{
		IwGameDemo.Instance.addView (this);
	}
	
	public void	initialize ()
	{}
	
	public void dispose ()
	{}
	
	public void notify ( IIwEvent evt )
	{
		if ( evt.name == IwPlayerView.PLAYER_WRONG )
		{
			renderer.material.color = Color.red;
			_inAttack = true;
			// here you can write your code for attack
		}
		else if ( evt.name == IwPlayerView.PLAYER_IS_SAFE )
		{
			renderer.material.color = Color.green;
			_inAttack = false;
			// here you can write your code for idle
		}
	}

	public bool inAttack 
	{
		get { return _inAttack; }
	}
	
	public string name 
	{ 
		set { gameObject.name = value;}
		get { return gameObject.name; } 
	}
	
	public IwEventDispatcher dispatcher { set { _dispatcher = value; } get { return _dispatcher; } }
	public List<string>  eventsToHand { get { return new List<string>{IwPlayerView.PLAYER_WRONG, IwPlayerView.PLAYER_IS_SAFE}; } }
}

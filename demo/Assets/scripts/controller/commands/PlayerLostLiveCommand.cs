using UnityEngine;
using System.Collections;

using Iwana.Controller;
using Iwana.Events;
using Iwana.Wire;

public class PlayerLostLiveCommand : IIwCommand 
{
	private Object _data = null;
	private IwEventDispatcher _dispatcher = null;

	public void initialize () {}

	public Object data { set { _data = value; } get { return _data; } }
	public IwEventDispatcher dispatcher { set { _dispatcher = value; } get { return _dispatcher; } }

	public void execute ( IIwEvent evt )
	{
		PlayerWire player = IwGameDemo.Instance.getWire (PlayerWire.NAME) as PlayerWire;
		if ( player != null )
		{
			player.lives--;
		}
	}
}

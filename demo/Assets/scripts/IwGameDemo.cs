using UnityEngine;
using System.Collections;

using Iwana;

public class IwGameDemo : IwGame 
{

	public static IwGameDemo Instance
	{
		private set;
		get;
	}

	void Awake ()
	{
		Instance = this;
		initialize ();
	}

	protected override void registerModels ()
	{
	}

	protected override void registerViews ()
	{
	}

	protected override void registerCommands ()
	{
		addCommand (IwPlayerView.PLAYER_LOSES_LIFE, typeof (PlayerLostLiveCommand));
	}

	protected override void registerWires ()
	{
		addWire (new PlayerWire ());
	}
}

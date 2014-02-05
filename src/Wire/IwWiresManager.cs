using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Iwana.Events;

namespace Iwana.Wire
{
	public class IwWiresManager 
	{
		private Dictionary <string, IIwWire> _wireList = null;
		private IwEventDispatcher _dispatcher = null;

		public IwWiresManager ( IwEventDispatcher dispatcher )
		{
			_dispatcher = dispatcher;
			_wireList = new Dictionary<string, IIwWire> ();
		}

		public void addWire ( IIwWire wire )
		{
			if ( wire == null )
			{
				Debug.LogError ( "Error in " + this + " Wire can't be null." );
				return;
			}

			if ( hasWire ( wire.name ) )
			{
				Debug.LogError ( "Error in " + this + " Wire '" + wire.name + "' already registered." );
				return;
			}

			lock ( _wireList )
			{
				_wireList[wire.name] = wire;
				wire.dispatcher = _dispatcher;
				wire.initialize ();
			}
		}

		public IIwWire getWire ( string wireName )
		{
			if ( !hasWire ( wireName ) ) return null;
			return _wireList [wireName];
		}

		public bool hasWire ( string wireName )
		{
			return _wireList.ContainsKey (wireName);
		}

		public void removeWire ( string wireName )
		{
			if ( !hasWire ( wireName ) )
			{
				Debug.LogError ( "Error in " + this + " Wire '" + wireName + "' not registered." );
				return;
			}
			
			lock ( _wireList )
			{
				_wireList [wireName] = null;
				_wireList.Remove (wireName);
			}
		}

		public void dispose ()
		{
			foreach ( KeyValuePair <string, IIwWire> tmpRegister in _wireList )
			{
				tmpRegister.Value.dispose ();
			}

			_wireList.Clear ();
			_dispatcher = null;
		}
	}
}
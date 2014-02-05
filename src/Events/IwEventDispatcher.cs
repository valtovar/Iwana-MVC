using UnityEngine;
using System.Collections;

namespace Iwana.Events
{
	public class IwEventDispatcher 
	{
		public event IwTriggerEvent OnTriggerEvent = null;

		public IwEventDispatcher ()
		{}

		public void triggerEvent ( IIwEvent evt )
		{
			if ( OnTriggerEvent != null )
			{
				OnTriggerEvent ( evt );
			}
		}
	}
}
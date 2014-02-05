using UnityEngine;
using System.Collections;

using Iwana.Model.Events;

namespace Iwana.Controller
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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Iwana.Model.Events;
using Iwana.Controller;

namespace Iwana.View
{
	public interface IIwView 
	{
		void 	initialize ();
		void 	dispose ();
		void	notify ( IIwEvent evt );

		string 	name { set; get; }
		IwEventDispatcher dispatcher { set; get; }
		List<string>  eventsToHand { get; }
	}
}
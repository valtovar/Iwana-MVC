using UnityEngine;
using System.Collections;

using Iwana.Events;

namespace Iwana.Wire
{
	public interface IIwWire  
	{
		string name { get; }
		IwEventDispatcher dispatcher { get; set; }
		void initialize ();
		void dispose ();
	}
}
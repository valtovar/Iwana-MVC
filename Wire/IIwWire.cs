using UnityEngine;
using System.Collections;

using Iwana.Controller;

namespace Iwana.Wire
{
	public interface IIwWire  
	{
		string name { set; get; }
		IwEventDispatcher dispatcher { get; set; }
		void initialize ();
		void dispose ();
	}
}
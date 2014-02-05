using UnityEngine;
using System.Collections;

using Iwana.Controller;

namespace Iwana.Model
{
	public interface IIwModel 
	{
		string 	name { set; get; }
		void 	initialize ();
		void 	dispose ();
		IwVO 	data { set; get; }
		IwEventDispatcher dispatcher { set; get; }
	}
}
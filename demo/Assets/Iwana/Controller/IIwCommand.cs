using UnityEngine;
using System.Collections;

using Iwana.Events;

namespace Iwana.Controller
{
	public interface IIwCommand 
	{
		void 	initialize ();
		Object 	data { set; get; }
		IwEventDispatcher dispatcher { set; get; }
		void 	execute ( IIwEvent evt );
	}
}
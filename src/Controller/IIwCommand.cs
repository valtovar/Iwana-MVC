using UnityEngine;
using System.Collections;

using Iwana.Events;
using Iwana.Model.VO;

namespace Iwana.Controller
{
	public interface IIwCommand 
	{
		void 	initialize ();
		IwVO 	data { set; get; }
		IwEventDispatcher dispatcher { set; get; }
		void 	execute ( IIwEvent evt );
	}
}
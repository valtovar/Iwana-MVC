using UnityEngine;
using System.Collections;

using Iwana.Events;
using Iwana.Model.VO;

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
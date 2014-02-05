using UnityEngine;
using System.Collections;

using Iwana.Model.VO;

namespace Iwana.Events
{
	public interface IIwEvent 
	{
		string 	name { set; get; }
		IwVO 	data { set; get; }
	}
}
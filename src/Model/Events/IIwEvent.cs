using UnityEngine;
using System.Collections;

namespace Iwana.Model.Events
{
	public interface IIwEvent 
	{
		string 	name { set; get; }
		Object 	data { set; get; }
	}
}
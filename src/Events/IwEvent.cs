using UnityEngine;
using System.Collections;

using Iwana.Model.VO;

namespace Iwana.Events
{
	public class IwEvent : IIwEvent 
	{
		private IwVO _data = null;
		private string _name = "";

		public IwEvent ( string name )
		{
			_name = name;
		}

		public IwEvent ( string name, IwVO data )
		{
			_name = name;
			_data = data;
		}

		public string name 
		{ 
			set { _name = value; }  
			get { return _name; } 
		}

		public IwVO data 
		{ 
			set { _data = value; } 
			get { return _data; } 
		}
	}
}
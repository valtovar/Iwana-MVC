using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Iwana.Controller;

namespace Iwana.Model
{
	public class IwModelsManager 
	{
		private Dictionary <string, IIwModel> _modelList = null;
		private IwEventDispatcher _dispatcher = null;

		public IwModelsManager ( IwEventDispatcher dispatcher )
		{
			_dispatcher = dispatcher;
			_modelList = new Dictionary<string, IIwModel> ();
		}

		public void addModel ( IIwModel model )
		{
			if ( model == null )
			{
				Debug.LogError ( "Error in " + this + " Model can't be null." );
				return;
			}

			if ( hasModel ( model.name ) )
			{
				Debug.LogError ( "Error in " + this + " Model '" + model.name + "' already registered." );
				return;
			}

			lock ( _modelList )
			{
				_modelList [model.name] = model;
				model.dispatcher = _dispatcher;
				model.initialize ();
			}
		}
		
		public bool hasModel ( string modelName )
		{
			return _modelList.ContainsKey (modelName);
		}
		
		public IIwModel getModel ( string modelName )
		{
			if ( !hasModel ( modelName ) ) return null;
			return _modelList [modelName];
		}
		
		public void removeModel ( string modelName )
		{
			if ( !hasModel ( modelName ) )
			{
				Debug.LogError ( "Error in " + this + " Model '" + modelName + "' not registered." );
				return;
			}

			lock ( _modelList )
			{
				_modelList [modelName] = null;
				_modelList.Remove (modelName);
			}
		}

		public void dispose ()
		{
			foreach ( KeyValuePair<string, IIwModel> item in _modelList )
			{
				item.Value.dispose ();
			}

			_modelList.Clear ();
			_dispatcher = null;
		}
	}
}
using UnityEngine;
using System.Collections;
using System;

using Iwana.Controller;
using Iwana.Model;
using Iwana.View;
using Iwana.Wire;

using Iwana.Model.Events;

namespace Iwana
{
	public abstract class IwGame : MonoBehaviour 
	{
		private IwController _controller = null;
		private IwModelsManager _modelsMgr = null;
		private IwViewsManager _viewsMgr = null;
		private IwWiresManager _wireMgr = null;

		private IwEventDispatcher _dispatcher = null;

		public void initialize ()
		{
			_dispatcher = new IwEventDispatcher ();
			_dispatcher.OnTriggerEvent += HandleOnTriggerEvent;

			_controller = new IwController ( _dispatcher );
			_modelsMgr = new IwModelsManager ( _dispatcher );
			_viewsMgr = new IwViewsManager ( _dispatcher );
			_wireMgr = new IwWiresManager (_dispatcher);
		}

		void HandleOnTriggerEvent (IIwEvent evt)
		{
			_controller.executeCommands (evt);
			_viewsMgr.notifyViews (evt);
		}
	
		protected abstract void registerModels ();
		protected abstract void registerViews ();
		protected abstract void registerCommands ();
		protected abstract void registerWires ();

		public void addCommand ( string commandName, Type commandClass )
		{
			System.Diagnostics.Debug.Assert (_controller == null, "Main Controller not exists!!!");
			_controller.addCommand (commandName, commandClass);
		}

		public bool hasCommand ( string commandName, Type commandClass )
		{
			System.Diagnostics.Debug.Assert (_controller == null, "Main Controller not exists!!!");
			return _controller.hasCommand (commandName, commandClass);
		}

		public bool hasCommandsByEvent ( string eventName )
		{
			System.Diagnostics.Debug.Assert (_controller == null, "Main Controller not exists!!!");
			return _controller.hasEvent (eventName);
		}

		public void removeCommand ( string commandName, Type commandClass )
		{
			System.Diagnostics.Debug.Assert (_controller == null, "Main Controller not exists!!!");
			_controller.removeCommand (commandName, commandClass);
		}

		public void addView ( IIwView view )
		{
			System.Diagnostics.Debug.Assert (_viewsMgr == null, "View Manager not exists!!!");
			_viewsMgr.addView (view);
		}

		public bool hasView ( string viewName )
		{
			System.Diagnostics.Debug.Assert (_viewsMgr == null, "View Manager not exists!!!");
			return _viewsMgr.hasView (viewName);
		}

		public void removeView ( string viewName )
		{
			System.Diagnostics.Debug.Assert (_viewsMgr == null, "View Manager not exists!!!");
			_viewsMgr.removeView (viewName);
		}

		public IIwView getView ( string viewName )
		{
			System.Diagnostics.Debug.Assert (_viewsMgr == null, "View Manager not exists!!!");
			return _viewsMgr.getView (viewName);
		}

		public void addModel ( IIwModel model )
		{
			System.Diagnostics.Debug.Assert (_modelsMgr == null, "Model Manager not exists!!!");
			_modelsMgr.addModel (model);
		}

		public bool hasModel ( string modelName )
		{
			System.Diagnostics.Debug.Assert (_modelsMgr == null, "Model Manager not exists!!!");
			return _modelsMgr.hasModel (modelName);
		}

		public void removeModel ( string modelName )
		{
			System.Diagnostics.Debug.Assert (_modelsMgr == null, "Model Manager not exists!!!");
			_modelsMgr.removeModel (modelName);
		}

		public IIwModel getModel ( string modelName )
		{
			System.Diagnostics.Debug.Assert (_modelsMgr == null, "Model Manager not exists!!!");
			return _modelsMgr.getModel (modelName);
		}

		public void addWire ( IIwWire wire )
		{
			System.Diagnostics.Debug.Assert (_wireMgr == null, "Wire Manager not exists!!!");
			_wireMgr.addWire (wire);
		}

		public bool hasWire ( string wireName )
		{
			System.Diagnostics.Debug.Assert (_wireMgr == null, "Wire Manager not exists!!!");
			return _wireMgr.hasWire (wireName);
		}

		public void removeWire ( string wireName )
		{
			System.Diagnostics.Debug.Assert (_wireMgr == null, "Wire Manager not exists!!!");
			_wireMgr.removeWire (wireName);
		}

		public IIwWire getWire ( string wireName )
		{
			System.Diagnostics.Debug.Assert (_wireMgr == null, "Wire Manager not exists!!!");
			return _wireMgr.getWire (wireName);
		}

		public IwController mainController
		{
			get
			{
				return _controller;
			}
		}

		public IwViewsManager viewsMgr 
		{
			get
			{
				return _viewsMgr;
			}
		}

		public IwModelsManager modelsMgr
		{
			get
			{
				return _modelsMgr;
			}
		}
	}
}
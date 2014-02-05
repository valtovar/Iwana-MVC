using UnityEngine;

//using System;
using System.Collections;
using System.Collections.Generic;

using Iwana.Controller;
using Iwana.Model.Events;

namespace Iwana.View
{
	public class IwViewsManager 
	{
		private Dictionary <string, IIwView> _viewList = null;
		private IwEventDispatcher _dispatcher = null;
		private Dictionary <string, List<IIwView>> _viewsForNotify = null;

		public IwViewsManager ( IwEventDispatcher dispatcher )
		{
			_dispatcher = dispatcher;
			_viewList = new Dictionary<string, IIwView> ();
			_viewsForNotify = new Dictionary<string, List<IIwView>> ();
		}

		public void addView (IIwView view)
		{
			if ( view == null )
			{
				Debug.LogError ( "Error in " + this + " View can't be null." );
				return;
			}

			if ( hasView ( view.name ) )
			{
				Debug.LogError ( "Error in " + this + " View '" + view.name + "' already registered." );
				return;
			}

			lock ( _viewList )
			{
				_viewList [view.name] = view;
				view.dispatcher = _dispatcher;

				if ( view.eventsToHand.Count > 0 )
				{
					foreach ( string eventToHand in view.eventsToHand )
					{
						if ( _viewsForNotify.ContainsKey ( eventToHand ) )
						{
							_viewsForNotify[eventToHand].Add ( view );
						}
						else 
						{
							List<IIwView> viewListsByEvent = new List<IIwView> ();
							viewListsByEvent.Add ( view );
							_viewsForNotify[eventToHand] = viewListsByEvent;
						}
					}
				}

				view.initialize ();
			}
		}

		public void notifyViews ( IIwEvent evt )
		{
			if ( !hasViewsByEvent ( evt.name ) )
				return;

			List<IIwView> tmpViewsToNotify = _viewsForNotify [evt.name];
			foreach ( IIwView tmpView in tmpViewsToNotify )
			{
				tmpView.notify ( evt );
			}
		}

		public bool hasViewsByEvent ( string eventName )
		{
			return _viewsForNotify.ContainsKey (eventName);
		}
		
		public bool hasView ( string viewName )
		{
			return _viewList.ContainsKey ( viewName );
		}
		
		public IIwView getView ( string viewName )
		{
			if ( !hasView ( viewName ) ) return null;

			return _viewList[viewName];
		}
		
		public void removeView ( string viewName )
		{
			if ( !hasView ( viewName ) )
			{
				Debug.Log ( "Error in " + this + " View '" + viewName + "' don't registered." );
				return;
			}

			lock ( _viewList )
			{
				_viewList [viewName] = null;
				_viewList.Remove (viewName);
			}
		}

		public void dispose ()
		{
			foreach ( KeyValuePair <string, IIwView> item in _viewList )
			{
				item.Value.dispose ();
			}

			_viewList.Clear ();
			_viewsForNotify.Clear ();
		}
	}
}
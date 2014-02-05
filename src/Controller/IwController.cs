using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using Iwana.Events;

namespace Iwana.Controller
{
	public class IwController  
	{
		private Dictionary <string, List<Type>> _commandList = null;
		private IwEventDispatcher _dispatcher = null;

		public IwController ( IwEventDispatcher dispatcher )
		{
			_dispatcher = dispatcher;
			_commandList = new Dictionary<string, List<Type>> ();
		}

		public void addCommand ( string commandName, Type commandClass )
		{
			if ( commandClass == null )
			{
				Debug.LogError ( "Error in " + this + " Command can't be null." );
			}

			if ( commandClass.GetInterface ("IIwCommand") == null )
			{
				Debug.LogError ( "Error in " + this + " Command Class must be extends of IIwCommand interface." );
			}

			lock ( _commandList )
			{
				if ( _commandList.ContainsKey ( commandName ) )
				{
					_commandList[commandName].Add ( commandClass );
				}
				else 
				{
					List<Type> commandListsByName = new List<Type> ();
					commandListsByName.Add ( commandClass );
					_commandList[commandName] = commandListsByName;
				}
			}
		}

		public bool hasEvent ( string eventName )
		{
			return _commandList.ContainsKey (eventName);
		}

		public bool hasCommand ( string commandName, Type commandClass )
		{
			if ( !_commandList.ContainsKey ( commandName ) ) return false;
			else
			{
				List<Type> tmpCommandListByName = _commandList[commandName];
				if ( tmpCommandListByName.Contains ( commandClass ) ) return true;
				else return false;
			}
		}

		public void removeCommand ( string commandName, Type commandClass )
		{
			if ( !hasCommand ( commandName, commandClass ) )
			{
				Debug.LogError ( "Error in " + this + " Command '" + commandName + "' not registered." );
				return;
			}

			lock ( _commandList )
			{
				List<Type> tmpCommandListByName = _commandList[commandName];
				tmpCommandListByName.Remove (commandClass);
			}
		}

		public void executeCommands ( IIwEvent evt )
		{
			if ( hasEvent ( evt.name ) )
			{
				List <Type> tmpCommandsByEventName = _commandList[evt.name];

				foreach ( Type tmpCommandClass in tmpCommandsByEventName )
				{
					IIwCommand tmpCommand = Activator.CreateInstance ( tmpCommandClass ) as IIwCommand;
					tmpCommand.dispatcher = _dispatcher;
					tmpCommand.execute ( evt );
				}
			}
		}

		public void dispose ()
		{
			foreach ( KeyValuePair<string,List<Type>> _commands in _commandList )
			{
				_commands.Value.Clear ();
			}

			_commandList.Clear ();
			_dispatcher = null;
		}
	}
}
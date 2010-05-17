// #######################################################
// 
// # Copyright (C) 2010, Arnold Zokas
// 
// # This source code is subject to terms and conditions of the New BSD License.
// # A copy of the license can be found in the license.txt file at the root of this distribution.
// # If you cannot locate the New BSD License, please send an email to arnold.zokas@coderoom.net.
// # By using this source code in any fashion, you are agreeing to be bound by the terms of the New BSD License.
// # You must not remove this notice, or any other, from this software.
// 
// #######################################################
using System;
using System.Collections.Generic;
using System.Xml;
using Xunit.Sdk;

namespace Xunit.Specifications
{
	internal static class SpecificationContext
	{
		private static List<KeyValuePair<string, Action>> _asserts;
		private static KeyValuePair<string, Action>? _context;
		private static KeyValuePair<string, Action>? _do;
		private static Exception _exception;

		static SpecificationContext()
		{
			Reset();
		}

		public static void Context(string message)
		{
			if (_exception != null)
				return;

			if (!_context.HasValue)
				_context = new KeyValuePair<string, Action>(message, null);
			else
				try
				{
					throw new InvalidOperationException("Cannot have two Context statements in one specification");
				}
				catch (Exception ex)
				{
					_exception = ex;
				}
		}

		public static void Context(string message, Action contextAction)
		{
			if (_exception != null)
				return;

			if (!_context.HasValue)
				_context = new KeyValuePair<string, Action>(message, contextAction);
			else
				try
				{
					throw new InvalidOperationException("Cannot have two Context statements in one specification");
				}
				catch (Exception ex)
				{
					_exception = ex;
				}
		}

		public static void Do(string message, Action doAction)
		{
			if (_exception != null)
				return;

			if (!_do.HasValue)
				_do = new KeyValuePair<string, Action>(message, doAction);
			else
				try
				{
					throw new InvalidOperationException("Cannot have two Do statements in one specification");
				}
				catch (Exception ex)
				{
					_exception = ex;
				}
		}

		public static void Assert(string message, Action assertAction)
		{
			_asserts.Add(new KeyValuePair<string, Action>(message, assertAction));
		}

		public static void Reset()
		{
			_exception = null;
			_context = null;
			_do = null;
			_asserts = new List<KeyValuePair<string, Action>>();
		}

		public static IEnumerable<ITestCommand> ToTestCommands(IMethodInfo method)
		{
			try
			{
				if (_exception == null && _asserts.Count == 0)
					try
					{
						throw new InvalidOperationException("Must have at least one Assert in each specification");
					}
					catch (Exception ex)
					{
						_exception = ex;
					}

				if (_exception == null && !_context.HasValue)
					try
					{
						throw new InvalidOperationException("Must have a Context in each specification");
					}
					catch (Exception ex)
					{
						_exception = ex;
					}

				if (_exception != null)
				{
					yield return new ExceptionTestCommand(method, _exception);
					yield break;
				}

				string name = _context.Value.Key;

				if (_do.HasValue)
					name += " " + _do.Value.Key;

				foreach (var kvp in _asserts)
				{
					var actions = new List<Action>();

					if (_context.Value.Value != null)
					{
						actions.Add(_context.Value.Value);
					}

					if (_do.HasValue) actions.Add(_do.Value.Value);
					actions.Add(kvp.Value);

					yield return new ActionTestCommand(method, name + ", " + kvp.Key, actions);
				}
			}
			finally
			{
				Reset();
			}
		}

		#region Nested type: ActionTestCommand

		private sealed class ActionTestCommand : ITestCommand
		{
			private readonly IEnumerable<Action> _actions;
			private readonly IMethodInfo _method;

			public ActionTestCommand(IMethodInfo method, string name, IEnumerable<Action> actions)
			{
				_method = method;
				_actions = actions;
				Name = name;
			}

			private string Name { get; set; }

			#region ITestCommand Members

			public bool ShouldCreateInstance
			{
				get { return false; }
			}

			public MethodResult Execute(object testClass)
			{
				foreach (var action in _actions)
					action();

				return new PassedResult(_method, Name);
			}

			public string DisplayName
			{
				get { return Name; }
			}

			public XmlNode ToStartXml()
			{
				var doc = new XmlDocument();
				doc.LoadXml("<dummy/>");
				XmlNode testNode = XmlUtility.AddElement(doc.ChildNodes[0], "start");

				XmlUtility.AddAttribute(testNode, "name", DisplayName);
				XmlUtility.AddAttribute(testNode, "type", _method.TypeName);
				XmlUtility.AddAttribute(testNode, "method", _method.Name);

				return testNode;
			}

			#endregion
		}

		#endregion
	}
}
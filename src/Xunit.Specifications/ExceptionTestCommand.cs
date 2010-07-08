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
using System.Xml;
using Xunit.Sdk;

namespace Xunit.Specifications
{
	public class ExceptionTestCommand : ITestCommand
	{
		private readonly Exception _exception;
		private readonly IMethodInfo _method;

		public ExceptionTestCommand(IMethodInfo method, Exception exception)
		{
			_method = method;
			_exception = exception;
		}

		public string Name
		{
			get { return null; }
		}

		#region ITestCommand Members

		public bool ShouldCreateInstance
		{
			get { return false; }
		}

		public int Timeout
		{
			get { return 0; }
		}

		public MethodResult Execute(object testClass)
		{
			return new FailedResult(_method, _exception, Name);
		}

		public string DisplayName
		{
			get { throw new NotImplementedException(); }
		}

		public virtual XmlNode ToStartXml()
		{
			var doc = new XmlDocument();
			doc.LoadXml("<dummy/>");
			XmlNode testNode = XmlUtility.AddElement(doc.ChildNodes[0], "start");

			string typeName = _method.TypeName;
			string methodName = _method.Name;

			XmlUtility.AddAttribute(testNode, "name", typeName + "." + methodName);
			XmlUtility.AddAttribute(testNode, "type", typeName);
			XmlUtility.AddAttribute(testNode, "method", methodName);

			return testNode;
		}

		#endregion
	}
}
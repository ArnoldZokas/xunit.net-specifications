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
	// TODO: implement and test
	internal class SpecificationTestCommand : ITestCommand
	{
		private readonly IMethodInfo _method;

		public SpecificationTestCommand(IMethodInfo method)
		{
			_method = method;
		}

		#region ITestCommand Members

		public MethodResult Execute(object testClass)
		{
			// TODO: implement
			return new PassedResult(_method, "TEST");
		}

		public XmlNode ToStartXml()
		{
			// TODO: test

			var doc = new XmlDocument();
			doc.LoadXml("<dummy/>");
			XmlNode testNode = XmlUtility.AddElement(doc.ChildNodes[0], "start");

			XmlUtility.AddAttribute(testNode, "name", "TEST");
			XmlUtility.AddAttribute(testNode, "type", _method.TypeName);
			XmlUtility.AddAttribute(testNode, "method", _method.Name);

			return testNode;
		}

		public string DisplayName
		{
			get { throw new NotImplementedException(); }
		}

		public bool ShouldCreateInstance
		{
			get { return false; }	// TODO: test
		}

		public int Timeout
		{
			get { return 0; }	// TODO: test
		}

		#endregion
	}
}
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
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace Xunit.Specifications
{
	public class SpecificationAttribute : FactAttribute
	{
		protected override IEnumerable<ITestCommand> EnumerateTestCommands(IMethodInfo method)
		{
			// TODO: test this
			// This executes method decorated with Specification attribute
			object obj = method.CreateInstance();
			method.Invoke(obj, null);

			return RuntimeContext.CurrentSpecificationContext.AssertExpressions.Select(assertExpression => new SpecificationTestCommand(method)).Cast<ITestCommand>();
		}
	}
}
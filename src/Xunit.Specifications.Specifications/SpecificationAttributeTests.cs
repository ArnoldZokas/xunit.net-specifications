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
using System.Diagnostics;
using System.Linq;
using Xunit.Sdk;

namespace Xunit.Specifications.Specifications
{
	public class SpecificationAttributeTests
	{
		[Fact]
		public void EnumerateTestCommands_returns_SpecificationContextCommands()
		{
			"context".Context(() => "string").Assert("not null", Assert.NotNull);
			var attribute = new SpecificationAttributeProxy();

			// need to mock IMethodInfo
			var commands = attribute.EnumerateTestCommands(null);

			Assert.Equal(1, commands.Count());
		}

		#region Nested type: SpecificationAttributeProxy

		private class SpecificationAttributeProxy : SpecificationAttribute
		{
			public new IEnumerable<ITestCommand> EnumerateTestCommands(IMethodInfo method)
			{
				return base.EnumerateTestCommands(method);
			}
		}

		#endregion
	}
}
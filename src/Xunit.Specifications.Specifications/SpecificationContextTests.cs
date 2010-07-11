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
using System.Linq;

namespace Xunit.Specifications.Specifications
{
	public class SpecificationContextTests
	{
		[FactAttribute]
		public void Assert_returns_SpecificationContext()
		{
			var context = "string".Context(() => new object()).Assert("message", x => Assert.Equal("string", x));

			Assert.IsType<SpecificationContext<object>>(context);
		}

		[FactAttribute]
		public void Assert_adds_AssertExpression_to_SpecificationContext()
		{
			var context = "string".Context(() => new object()).Assert("message", x => Assert.Equal("string", x));

			Assert.Equal(1, context.AssertExpressions.Count);
		}

		[FactAttribute]
		public void Assert_adds_AssertExpression_to_SpecificationContext_with_Message()
		{
			var context = "string".Context(() => new object()).Assert("message", x => Assert.Equal("string", x));

			Assert.Equal("message", context.AssertExpressions.First().Message);
		}

		[FactAttribute]
		public void Assert_adds_AssertExpression_to_SpecificationContext_with_TestExpression()
		{
			Action<object> testExpression = x => Assert.Equal("string", x);

			var context = "string".Context(() => new object()).Assert("message", testExpression);

			Assert.Equal(testExpression, context.AssertExpressions.First().TestExpression);
		}
	}
}
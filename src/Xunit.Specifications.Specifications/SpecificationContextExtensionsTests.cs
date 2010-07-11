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

namespace Xunit.Specifications.Specifications
{
	public class SpecificationContextExtensionsTests
	{
		[FactAttribute]
		public void Context_sets_RuntimeContext_CurrentSpecificationContext()
		{
			var context = "string".Context(() => new object());

			Assert.Equal(context, RuntimeContext.CurrentSpecificationContext);
		}

		[FactAttribute]
		public void Context_returns_SpecificationContext()
		{
			var context = "string".Context(() => new object());

			Assert.IsType<SpecificationContext<object>>(context);
		}

		[FactAttribute]
		public void Context_returns_SpecificationContext_with_Message()
		{
			var context = "message".Context(() => new object());

			Assert.Equal("message", context.Message);
		}

		[FactAttribute]
		public void Context_returns_SpecificationContext_with_InitialisationExpression()
		{
			Func<object> initialisationExpression = () => new object();

			var context = "string".Context(initialisationExpression);

			Assert.Equal(initialisationExpression, context.InitialisationExpression);
		}
	}
}
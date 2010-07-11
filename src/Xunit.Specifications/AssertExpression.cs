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

namespace Xunit.Specifications
{
	internal sealed class AssertExpression<T> : IAssertExpression
	{
		internal AssertExpression(string message, Action<T> testExpression)
		{
			Message = message;
			TestExpression = testExpression;
		}

		#region IAssertExpression Members

		public string Message { get; private set; }
		public object TestExpression { get; set; }

		#endregion
	}
}
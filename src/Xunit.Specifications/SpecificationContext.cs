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

namespace Xunit.Specifications
{
	public class SpecificationContext<T> : SpecificationContextBase
	{
		private readonly IList<IAssertExpression> _assertExpressions;

		internal SpecificationContext(string message, Func<T> initialisationExpression)
		{
			Message = message;
			InitialisationExpression = initialisationExpression;
			_assertExpressions = new List<IAssertExpression>();
		}

		internal string Message { get; private set; }
		internal Func<T> InitialisationExpression { get; private set; }

		internal override IList<IAssertExpression> AssertExpressions
		{
			get { return _assertExpressions; }
		}

		public SpecificationContext<T> Assert(string message, Action<T> testExpression)
		{
			AssertExpressions.Add(new AssertExpression<T>(message, testExpression));

			return this;
		}
	}
}
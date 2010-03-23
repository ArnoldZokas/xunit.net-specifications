//  #######################################################
//  
//  # Copyright (C) Arnold Zokas 2010
//  
//  # This source code is subject to terms and conditions of the New BSD License.
//  # A copy of the license can be found in the license.txt file at the root of this distribution.
//  # If you cannot locate the New BSD License, please send an email to arnold.zokas@coderoom.net.
//  # By using this source code in any fashion, you are agreeing to be bound by the terms of the New BSD License.
//  # You must not remove this notice, or any other, from this software.
//  
//  #######################################################
using System;

namespace Xunit.Specifications
{
	public static class SpecificationExtensions
	{
		public static void Context(this string message)
		{
			SpecificationContext.Context(message);
		}

		public static void Context(this string message, Action arrange)
		{
			SpecificationContext.Context(message, arrange);
		}

		public static void Do(this string message, Action act)
		{
			SpecificationContext.Do(message, act);
		}

		public static void Assert(this string message, Action assert)
		{
			SpecificationContext.Assert(message, assert);
		}
	}
}
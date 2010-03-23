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
using System.Collections.Generic;
using Xunit.Sdk;

namespace Xunit.Specifications
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class SpecificationAttribute : FactAttribute
	{
		protected override IEnumerable<ITestCommand> EnumerateTestCommands(IMethodInfo method)
		{
			try
			{
				object obj = method.CreateInstance();
				method.Invoke(obj, null);
				return SpecificationContext.ToTestCommands(method);
			}
			catch (Exception ex)
			{
				return new ITestCommand[] {new ExceptionTestCommand(method, ex)};
			}
		}
	}
}
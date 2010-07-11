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
namespace Xunit.Specifications.Specifications
{
	public class AssertExtensionSpecifications
	{
		[Specification]
		public void Equal()
		{
			"Given string \"test\"".Context(() => "test").Assert("length is 4", x => Assert.Equal(4, x.Length));
		}
	}
}
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
using System.Collections;
using System.Collections.Generic;

namespace Xunit.Specifications
{
	public static class AssertExtensions
	{
		#region ShouldContain

		public static void ShouldContain(this string actualString, string expectedSubString)
		{
			Assert.Contains(expectedSubString, actualString);
		}

		public static void ShouldContain<T>(this IEnumerable<T> collection, T expected)
		{
			Assert.Contains(expected, collection);
		}

		public static void ShouldNotContain(this string actualString, string expectedSubString)
		{
			Assert.DoesNotContain(expectedSubString, actualString);
		}

		public static void ShouldNotContain<T>(this IEnumerable<T> collection, T expected)
		{
			Assert.DoesNotContain(expected, collection);
		}

		#endregion

		#region ShouldBeEmpty

		public static void ShouldBeEmpty(this IEnumerable collection)
		{
			Assert.Empty(collection);
		}

		public static void ShouldNotBeEmpty(this IEnumerable collection)
		{
			Assert.NotEmpty(collection);
		}

		#endregion

		#region ShouldEqual<T>

		public static void ShouldEqual<T>(this T actual, T expected)
		{
			Assert.Equal(expected, actual);
		}

		public static void ShouldNotEqual<T>(this T actual, T expected)
		{
			Assert.NotEqual(expected, actual);
		}

		#endregion

		#region ShouldBeInRange<T>

		public static void ShouldBeInRange<T>(this T actual, T low, T high)
		{
			Assert.InRange(actual, low, high);
		}

		public static void ShouldNotBeInRange<T>(this T actual, T low, T high)
		{
			Assert.NotInRange(actual, low, high);
		}

		#endregion

		#region ShouldBeOfType<T>

		public static void ShouldBeOfType<T>(this object @object)
		{
			Assert.IsType<T>(@object);
		}

		public static void ShouldNotBeOfType<T>(this object @object)
		{
			Assert.IsNotType<T>(@object);
		}

		#endregion

		#region ShouldBeAssignableFrom<T>

		public static void ShouldBeAssignableFrom<T>(this object @object)
		{
			Assert.IsAssignableFrom<T>(@object);
		}

		#endregion

		#region ShouldBeNull

		public static void ShouldBeNull(this object @object)
		{
			Assert.Null(@object);
		}

		public static void ShouldNotBeNull(this object @object)
		{
			Assert.NotNull(@object);
		}

		#endregion

		#region ShouldBeSame

		public static void ShouldBeSameAs(this object actual, object expected)
		{
			Assert.Same(expected, actual);
		}

		public static void ShouldNotBeSameAs(this object actual, object expected)
		{
			Assert.NotSame(expected, actual);
		}

		#endregion

		#region ShouldBeTrue

		public static void ShouldBeTrue(this bool condition)
		{
			Assert.True(condition);
		}

		public static void ShouldBeFalse(this bool condition)
		{
			Assert.False(condition);
		}

		#endregion
	}
}
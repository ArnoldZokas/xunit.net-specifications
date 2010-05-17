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
using Xunit.Sdk;

namespace Xunit.Specifications.Specifications
{
	public class AssertExtensionsSpecifications
	{
		[Specification]
		public void ShouldContainStringSpecifications()
		{
			string target = null;
			"Given a \"Hello, world!\" string".Context(() => target = "Hello, world!");

			"ShouldContain passes when \"world\" is passed".Assert(() => target.ShouldContain("world"));
			"ShouldContain throws ContainsException when \"TEST\" is passed".AssertThrows<ContainsException>(() => target.ShouldContain("TEST"));
			"ShouldNotContain passes when \"TEST\" is passed".Assert(() => target.ShouldNotContain("TEST"));
			"ShouldNotContain throws DoesNotContainException when \"world\" is passed".AssertThrows<DoesNotContainException>(() => target.ShouldNotContain("world"));
		}

		[Specification]
		public void ShouldContainGenericIEnumerableSpecifications()
		{
			int[] target = null;
			"Given a new array".Context(() => target = new int[3]);

			"populated with 1,2,3".Do(() =>
			                          	{
			                          		target[0] = 1;
			                          		target[1] = 2;
			                          		target[2] = 3;
			                          	});

			"ShouldContain passes when 2 is passed".Assert(() => target.ShouldContain(2));
			"ShouldContain throws ContainsException when 0 is passed".AssertThrows<ContainsException>(() => target.ShouldContain(0));
			"ShouldNotContain passes when 0 is passed".Assert(() => target.ShouldNotContain(0));
			"ShouldNotContain throws DoesNotContainException when 2 is passed".AssertThrows<DoesNotContainException>(() => target.ShouldNotContain(2));
		}

		[Specification]
		public void ShouldBeEmptyIEnumerableSpecifications()
		{
			"Given an empty array".Context();

			"ShouldBeEmpty passes".Assert(() => new int[0].ShouldBeEmpty());
			"ShouldNotBeEmpty throws NotEmptyException".AssertThrows<NotEmptyException>(() => new int[0].ShouldNotBeEmpty());
		}

		[Specification]
		public void ShouldBeEmptyIEnumerableSpecifications2()
		{
			"Given an non-empty array".Context();

			"ShouldNotBeEmpty passes".Assert(() => new[] {1}.ShouldNotBeEmpty());
			"ShouldBeEmpty throws EmptyException".AssertThrows<EmptyException>(() => new[] {1}.ShouldBeEmpty());
		}

		[Specification]
		public void ShouldEqualSpecifications()
		{
			"Given a string".Context();

			"ShouldEqual passes when the same string is passed".Assert(() => "TEST".ShouldEqual("TEST"));
			"ShouldEqual throws EqualException when a different string is passed".AssertThrows<EqualException>(() => "TEST".ShouldEqual("42"));
			"ShouldNotEqual passes when a different string is passed".Assert(() => "TEST".ShouldNotEqual("42"));
			"ShouldNotEqual throws NotEqualException when the same string is passed".AssertThrows<NotEqualException>(() => "TEST".ShouldNotEqual("TEST"));
		}

		[Specification]
		public void ShouldBeInRangeSpecifications()
		{
			"Given number 42".Context();

			"ShouldBeInRange passes when range 41-43 is passed".Assert(() => 42.ShouldBeInRange(41, 43));
			"ShouldBeInRange throws InRangeException when range 40-41 is passed".AssertThrows<InRangeException>(() => 42.ShouldBeInRange(40, 41));
			"ShouldNotBeInRange passes when range 40-41 is passed".Assert(() => 42.ShouldNotBeInRange(40, 41));
			"ShouldNotBeInRange throws NotInRangeException when range 41-43 is passed".AssertThrows<NotInRangeException>(() => 42.ShouldNotBeInRange(41, 43));
		}

		[Specification]
		public void ShouldBeOfTypeSpecifications()
		{
			"Given a string".Context();

			"ShouldBeOfType passes when <string> is passed".Assert(() => "string".ShouldBeOfType<string>());
			"ShouldBeOfType throws IsTypeException when <object> is passed".AssertThrows<IsTypeException>(() => "string".ShouldBeOfType<object>());
			"ShouldNotBeOfType passes when <object> is passed".Assert(() => "string".ShouldNotBeOfType<object>());
			"ShouldNotBeOfType throws IsNotTypeException when <string> is passed".AssertThrows<IsNotTypeException>(() => "string".ShouldNotBeOfType<string>());
		}

		[Specification]
		public void ShouldBeAssignableFromSpecifications()
		{
			"Given a string".Context();

			// ReSharper disable RedundantTypeArgumentsOfMethod
			"ShouldBeAssignableFrom passes when <string> is passed".Assert(() => "string".ShouldBeAssignableFrom<string>());
			"ShouldBeAssignableFrom throws IsAssignableFromException when <int> is passed".AssertThrows<IsAssignableFromException>(() => "string".ShouldBeAssignableFrom<int>());
			// ReSharper restore RedundantTypeArgumentsOfMethod
		}

		[Specification]
		public void ShouldBeNullSpecifications()
		{
			object target = null;
			"Given a empty reference".Context();

			"ShouldBeNull passes".Assert(() => target.ShouldBeNull());
			"ShouldNotBeNull throws NotNullException".AssertThrows<NotNullException>(() => target.ShouldNotBeNull());
		}

		[Specification]
		public void ShouldBeNullSpecifications2()
		{
			"Given a string".Context();

			"ShouldNotBeNull passes".Assert(() => "string".ShouldNotBeNull());
			"ShouldBeNull throws NullException".AssertThrows<NullException>(() => "string".ShouldBeNull());
		}

		[Specification]
		public void ShouldBeSameAsSpecifications()
		{
			object target = null;
			"Given a new object".Context(() => new object());

			"ShouldBeSameAs passes when same object is passed".Assert(() => target.ShouldBeSameAs(target));
			"ShouldBeSameAs throws SameException when a different object is passed".AssertThrows<SameException>(() => target.ShouldBeSameAs(new object()));
			"ShouldNotBeSameAs passes when a different object is passed".Assert(() => target.ShouldNotBeSameAs(new object()));
			"ShouldNotBeSameAs throws NotSameException when same object is passed".AssertThrows<NotSameException>(() => target.ShouldNotBeSameAs(target));
		}

		[Specification]
		public void ShouldBeTrueFalseSpecifications()
		{
			"".Context();

			"ShouldBeTrue passes invoked on <true>".Assert(() => true.ShouldBeTrue());
			"ShouldBeTrue throws TrueException when invoked on <false>".AssertThrows<TrueException>(() => false.ShouldBeTrue());
			"ShouldBeFalse passes when invoked on <false>".Assert(() => false.ShouldBeFalse());
			"ShouldBeFalse throws FalseException when invoked on <true>".AssertThrows<FalseException>(() => true.ShouldBeFalse());
		}
	}
}
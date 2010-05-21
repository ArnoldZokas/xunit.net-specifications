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
using System.Linq;

namespace Xunit.Specifications.Samples
{
	public class ShoppingCartSpecifications
	{
		[Specification]
		public void ConstructorSpecifications()
		{
			ShoppingCart cart = null;
			"Given new ShoppingCart".Context(() => cart = new ShoppingCart());

			"number of Items is 0".Assert(() => cart.Items.Count.ShouldEqual(0));
		}

		[Specification]
		public void AddItemSpecifications()
		{
			ShoppingCart cart = null;
			"Given new ShoppingCart".Context(() => cart = new ShoppingCart());

			"when AddItem is called".Do(() => cart.AddItem("Cake"));

			"number of Items is 1".Assert(() => cart.Items.Count.ShouldEqual(1));
			"first Item is \"Cake\"".Assert(() => cart.Items.First().ShouldEqual("Cake"));
		}

		[Specification]
		public void AddItemInputValidationSpecifications()
		{
			ShoppingCart cart = null;
			"Given new ShoppingCart".Context(() => cart = new ShoppingCart());

			"AddItem throws when ArgumentNullException when null product name is passed".AssertThrows<ArgumentNullException>(() => cart.AddItem(null));
		}

		#region Nested type: ShoppingCart

		public class ShoppingCart
		{
			public static int MaxItems = 5;

			public ShoppingCart()
			{
				Items = new List<string>();
			}

			public List<string> Items { get; private set; }

			public void AddItem(string productName)
			{
				if (productName == null)
					throw new ArgumentNullException("productName");

				Items.Add(productName);
			}
		}

		#endregion
	}
}
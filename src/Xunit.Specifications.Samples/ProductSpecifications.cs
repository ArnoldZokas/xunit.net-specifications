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

namespace Xunit.Specifications.Samples
{
	public class ProductSpecifications
	{
		[Specification]
		public void ConstructorSpecifications()
		{
			Product product = null;
			"Given new Product".Context(() => product = new Product("Epic Cake", 10.00M, true, new List<string> {"cakes"}));

			"Name should contain \"Cake\"".Assert(() => product.Name.ShouldContain("Cake"));
			"Name should be \"Epic Cake\"".Assert(() => product.Name.ShouldEqual("Epic Cake"));
			"Name should be \"Epic Cake\"".Assert(() => product.Name.ShouldBeSameAs("Epic Cake"));
			"Price should be between 9.5 and 11".Assert(() => product.Price.ShouldBeInRange(9.5M, 11M));
			"IsNew should be true".Assert(() => product.IsNew.ShouldBeTrue());
			"Category should be null".Assert(() => product.Category.ShouldBeNull());
			"Tags should contain tag \"cakes\"".Assert(() => product.Tags.ShouldContain("cakes"));
			"RelatedProducts should be empty".Assert(() => product.RelatedProducts.ShouldBeEmpty());
			"Price is of type Decimal".Assert(() => product.Price.ShouldBeOfType<Decimal>());
			"base class is BaseProduct".Assert(() => product.ShouldBeAssignableFrom<BaseProduct>());
		}

		#region Nested type: BaseProduct

		public abstract class BaseProduct
		{
		}

		#endregion

		#region Nested type: Product

		public class Product : BaseProduct
		{
			public Product(string name, decimal price, bool inStock, List<string> tags)
			{
				Name = name;
				Price = price;
				IsNew = inStock;
				Tags = tags;
				RelatedProducts = new List<string>();
			}

			public string Name { get; set; }
			public decimal Price { get; set; }
			public bool IsNew { get; set; }
			public string Category { get; set; }
			public List<string> Tags { get; set; }
			public List<string> RelatedProducts { get; set; }
		}

		#endregion
	}
}
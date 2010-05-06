//  #######################################################
//  
//  # Copyright (C) 2010, Arnold Zokas
//  
//  # This source code is subject to terms and conditions of the New BSD License.
//  # A copy of the license can be found in the license.txt file at the root of this distribution.
//  # If you cannot locate the New BSD License, please send an email to arnold.zokas@coderoom.net.
//  # By using this source code in any fashion, you are agreeing to be bound by the terms of the New BSD License.
//  # You must not remove this notice, or any other, from this software.
//  
//  #######################################################
using System.Collections.Generic;

namespace Xunit.Specifications.Specifications.AcceptanceTests
{
	public class OrderSpecifications
	{
		[Specification]
		public void AddOrderLineSpecifications()
		{
			Order order = null;

			"Given a new order".Context(() => order = new Order());

			"with 1 order line added".Do(() => order.AddOrderLine(null));

			"order should contain 1 order line".Assert(() => Assert.Equal(1, order.OrderLines.Count));
		}

		#region Nested type: Order

		private class Order
		{
			public Order()
			{
				OrderLines = new List<object>();
			}

			public List<object> OrderLines { get; private set; }

			public void AddOrderLine(object value)
			{
				OrderLines.Add(value);
			}
		}


		#endregion
	}
}
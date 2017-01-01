using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Domain.Entities
{
    class Order
    {
        private IList<LineItem> lineItems;
        private double orderTotal;

        public int Id { get; }
        public int LineItemCount => lineItems.Count();

        /// <summary>
        /// Create a new Order.
        /// </summary>
        public Order()
        {
            lineItems = new List<LineItem>();
        }

        /// <summary>
        /// Create a new Order with the given Id.
        /// </summary>
        /// <param name="id">A unique identifier for the order.</param>
        public Order(int id)
        {
            Id = id;
            lineItems = new List<LineItem>();
        }

        /// <summary>
        /// Add a LineItem to the Order.
        /// </summary>
        /// <param name="lineItem">The LineItem to add to the Order.</param>
        public void AddLineItem(LineItem lineItem)
        {
            lineItems.Add(lineItem);
        }

        /// <summary>
        /// Calculate the total price of the Order.
        /// </summary>
        /// <returns>The total price of the Order.</returns>
        public double CalulateOrderTotal()
        {
            foreach (LineItem lineItem in lineItems)
            {
                orderTotal += lineItem.Price;
            }

            return orderTotal;
        }
    }
}

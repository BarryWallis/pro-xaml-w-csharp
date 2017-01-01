using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Domain.Entities;
using Purchasing.Domain.Service.Interfaces;

namespace Purchasing.Domain.Service
{
    class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;

        /// <summary>
        /// Create an OrderService for the given OrderRepository.
        /// </summary>
        /// <param name="orderRepository">The OrderRepsository to use.</param>
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        /// <summary>
        /// Create an invoice from the given Order.
        /// </summary>
        /// <param name="order">The Order to create the Invoice from.</param>
        /// <returns>The invoice that was created from the Order.</returns>
        public Invoice CreateInvoice(Order order)
        {
            orderRepository.AddOrder(order);
            orderRepository.Commit();
            Invoice invoice = new Invoice { OrderTotal = order.CalulateOrderTotal() };
            return invoice;
        }
    }
}

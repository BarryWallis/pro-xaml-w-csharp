using Purchasing.Domain.Entities;

namespace Purchasing.Domain.Service
{
    internal interface IOrderRepository
    {
        void AddOrder(Order order);
        void Commit();
    }
}
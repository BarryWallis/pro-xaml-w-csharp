using System.Collections.Generic;
using DesignPatterns.Entities;

namespace DesignPatterns.UnitOfWork.Interfaces
{
    internal interface IUnitOfWork
    {
        IEnumerable<Product> Products { get; }

        Product Save(Product newProduct);
        void Add(Product newProduct);
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Entities;
using DesignPatterns.Repository.Interfaces;
using DesignPatterns.UnitOfWork.Interfaces;

namespace DesignPatterns.Repository
{
    //TODO consider adding repositories to the unit of work to
    //implement an entity framework Uow with DBSet<Product> collections.

    class ProductRepository : IProductRepository
    {
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// Create a new ProductRepository.
        /// </summary>
        /// <param name="unitOfWork">The UnitOfWork that holds the ProductRepository.</param>
        public ProductRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork is null)
                throw new ArgumentNullException(nameof(unitOfWork));
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Return the product with the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product with the given <paramref name="id"/>.</returns>
        public Product GetProduct(int id)
        {
            Debug.Assert(unitOfWork != null);

            return unitOfWork.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Return all the products in the UnitOfWork.
        /// </summary>
        /// <returns>All the Products in the UnitOfWork.</returns>
        public IEnumerable<Product> GetProducts()
        {
            Debug.Assert(unitOfWork != null);

            return unitOfWork.Products;
        }

        /// <summary>
        /// Create a new Product and add it to the UnitOfWork.
        /// </summary>
        /// <param name="createInDatabase">True if the product should be stored in the database, otherwise false.</param>
        /// <returns>The new Product.</returns>
        public Product NewProduct(bool createInDatabase)
        {
            Debug.Assert(unitOfWork != null);

            Product newProduct = new Product();
            if (createInDatabase)
                newProduct = unitOfWork.Save(newProduct);
            else
                unitOfWork.Add(newProduct);
            return newProduct;
        }

        /// <summary>
        /// Save a Product to the database.
        /// </summary>
        /// <param name="product">The Product to save.</param>
        /// <returns>The Product that was saved (with a new Id if it had to be added to the database).</returns>
        public Product SaveProduct(Product product)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));
            Debug.Assert(unitOfWork != null);

            return unitOfWork.Save(product);
        }
    }
}

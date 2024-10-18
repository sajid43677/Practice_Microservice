using AutoMapper;
using Core.Domains;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repository;
        public ProductService(IProductRepo repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetProductById(id);
        }

        public bool CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _repository.CreateProduct(product);
            return _repository.SaveChanges();
        }

        public IEnumerable<Product> GetProductsAbovePrice(int price)
        {
            return _repository.GetAllProducts().Where(p => p.Price > price).ToList();
        }
    }
}

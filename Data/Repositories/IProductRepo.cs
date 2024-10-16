﻿using Core.Domains;

namespace Data.Repositories
{
    public interface IProductRepo
    {
        bool SaveChanges();
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
    }
}

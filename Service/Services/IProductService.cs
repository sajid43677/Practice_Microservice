using Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IProductService
    {
        bool CreateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        IEnumerable<Product> GetProductsAbovePrice(int price);
    }
}

namespace Product.Data
{
    public interface IProductRepo
    {
        bool SaveChanges();
        IEnumerable<Models.Product> GetAllProducts();
        Models.Product GetProductById(int id);
        void CreateProduct(Models.Product product);
    }
}

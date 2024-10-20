namespace Service.Models
{
    public class ProductListModel
    {
        public ProductListModel()
        {
            ProductReadModels = new List<ProductReadModel>();
        }

        public List<ProductReadModel> ProductReadModels { get; set; }
    }
}

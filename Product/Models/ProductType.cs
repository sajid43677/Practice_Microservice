using GraphQL.Types;

namespace ProductService.Models
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id).Description("Product ID");
            Field(x => x.Name).Description("Product Name");
            Field(x => x.Price).Description("Product Price");
        }
    }
}

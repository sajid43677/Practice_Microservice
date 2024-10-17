using GraphQL.Types;

namespace ProductService.Utilities;
public class ProductSchema : Schema
{

    public ProductSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<ProductQuery>();
        Mutation = provider.GetRequiredService<ProductMutation>();
    }
}

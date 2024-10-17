using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Utilities;

public class ProductQuery : ObjectGraphType
{
    public ProductQuery(IProductRepo productRepo)
    {
        AddField(new FieldType
        {
            Name = "products",
            Type = typeof(ListGraphType<ProductType>),
            Resolver = new FuncFieldResolver<IEnumerable<Product>>(context => [])
        });

        AddField(new FieldType
        {
            Name = "product",
            Arguments = new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
            Type = typeof(ProductType),
            Resolver = new FuncFieldResolver<Product>(context => productRepo.GetProductById(context.GetArgument<int>("id")))
        });
    }
}


using EntityGraphQL.Schema;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using ProductService.Data;
using ProductService.Models;
using System.Linq.Expressions;
using System;

namespace ProductService.Utilities;
public class ProductMutation : ObjectGraphType
{
    [GraphQLMutation("Add a new product to the system")]
    public Expression<Func<AppDbContext, Product>> AddNewProduct(AppDbContext db, string name, int price)
    {
        var product = new Product
        {
            Name = name,
            Price = price,
        };
        db.Products.Add(product);
        db.SaveChanges();

        return (ctx) => ctx.Products.First(p => p.Id == product.Id);
    }
}

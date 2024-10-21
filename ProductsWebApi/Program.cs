using Butterfly.Client.AspNetCore;
using Data.Configuration;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using ProductsWebApi.Factories;
using ProductsWebApi.Types;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddButterfly(option =>
{
    option.CollectorUrl = "http://localhost:9618";
    option.Service = "ProductWebApi";
});

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductModelFactory, ProductModelFactory>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<Query>();

// Register GraphQL
builder.Services.AddGraphQLServer()
    .RegisterDbContextFactory<AppDbContext>()  // Register the factory for GraphQL
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();
app.Run();

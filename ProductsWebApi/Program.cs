using Butterfly.Client.AspNetCore;
using Butterfly.DataContract.Tracing;
using Data.Configuration;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using ProductsWebApi.Factories;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddButterfly(option =>
{
    option.CollectorUrl = "http://localhost:9618";
    option.Service = "ProductWebApi";
});

// Add services to the container.
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductModelFactory, ProductModelFactory>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//add database connetction
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();

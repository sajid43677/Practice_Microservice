using ApiGateway;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Add logging to the console
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Add HttpClient service
builder.Services.AddHttpClient("withLogging")
    .AddHttpMessageHandler<CustomDelegatingHandler>();

builder.Services.AddOcelot()
    .AddDelegatingHandler<CustomDelegatingHandler>();


// Add services to the container.

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

await app.UseOcelot();

app.Run();

using Catalog.Application.Products.Queries;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Registra MediatR e os handlers do Assembly onde estão as Queries/Commands
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetProductByIdQuery).Assembly));

var app = builder.Build();

app.MapGet("/test", async (IProductRepository repository) =>
{
    var product = new Product { Name = "Test", Price = 10.99m };
    //await repository.AddAsync(product);
    return Results.Ok(product);
});

app.MapGet("/products/{id}", async (Guid id, IMediator mediator) =>
{
    var query = new GetProductByIdQuery(id);

    var product = await mediator.Send(query);

    return Results.Ok(product);
});

app.UseRouting();

app.Run();

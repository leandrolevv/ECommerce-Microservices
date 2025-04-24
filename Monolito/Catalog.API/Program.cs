
using Catalog.Application.Categories.Commands.CreateCategory;
using Catalog.Application.Categories.Commands.DeleteCategory;
using Catalog.Application.Categories.Queries.GetAllCategory;
using Catalog.Application.Categories.Queries.GetCategoryById;
using Catalog.Application.Common.Behaviors;
using Catalog.Application.Filters;
using Catalog.Application.Products.Commands.CreateProduct;
using Catalog.Application.Products.Commands.DeleteProduct;
using Catalog.Application.Products.Commands.UpdateProduct;
using Catalog.Application.Products.Dtos;
using Catalog.Application.Products.Queries.GetProductById;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Catalog.Application.AssemblyReference).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
var app = builder.Build();

app.MapGet("/products/{id}", async (Guid id, IMediator mediator) =>
{
    var query = new GetProductByIdQuery(id);

    var product = await mediator.Send(query);

    return Results.Ok(product);
});

app.MapGet("/categories/{id}", async (Guid id, IMediator mediator) =>
{
    var query = new GetCategoryByIdQuery(id);

    var category = await mediator.Send(query);

    if (category == null)
        return Results.NotFound();

    return Results.Ok(category);
});

app.MapGet("/categories", async (IMediator mediator) =>
{
    var query = new GetAllCategoryQuery();

    var category = await mediator.Send(query);

    if (category != null)
        return Results.NotFound();
    
    return Results.Ok(category);
});

app.MapPost("/products", async (Product product, IMediator mediator) =>
{
    var command = new CreateProductCommand(product.Name, product.Price, product.Stock, product.CategoryId);
    var productResult = await mediator.Send(command);
    return Results.Created($"/products/{productResult}", productResult);
});

app.MapPost("/categories", async (Category category, IMediator mediator) =>
{                    
    var command = new CreateCategoryCommand(category.Name);
    var categoryResult = await mediator.Send(command);
    return Results.Created($"/categories/{categoryResult}", categoryResult);
});

app.MapDelete("/categories/{id}", async (Guid id, IMediator mediator) =>
{
    var command = new DeleteCategoryCommand(id);
    await mediator.Send(command);
    return Results.NoContent();
});

app.MapPut("/products/{id}", async (Guid id, Product product, IMediator mediator) =>
{
    var command = new UpdateProductCommand(id, product.Name, product.Price, product.Stock);
    var productResult = await mediator.Send(command);
    return Results.Ok(productResult);
}).AddEndpointFilter<ValidationFilter>();


app.UseRouting();

app.Run();

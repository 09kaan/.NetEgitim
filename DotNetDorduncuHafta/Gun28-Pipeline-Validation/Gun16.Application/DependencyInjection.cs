using Gun16.Application.Interfaces;
using Gun16.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Gun16.Application.Features.Brands.Commands.CreateBrand;
using Gun16.Application.Features.Brands.Queries.GetAllBrands;
using Gun16.Application.Features.Products.Commands.CreateProduct;
using Gun16.Application.Features.Products.Commands.UpdateProduct;
using Gun16.Application.Features.Products.Commands.DeleteProduct;
using Gun16.Application.Features.Products.Queries.GetAllWithCategory;
using Gun16.Application.Features.Products.Queries.GetByIdWithCategory;
using FluentValidation;
using Gun16.Application.Behaviors;

namespace Gun16.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<IBrandService, BrandService>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetAllWithCategoryQueryHandler).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);

        return services;
    }
}
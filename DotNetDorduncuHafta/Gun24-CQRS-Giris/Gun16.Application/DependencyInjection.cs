using Gun16.Application.Interfaces;
using Gun16.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Gun16.Application.Features.Brands.Commands.CreateBrand;
using Gun16.Application.Features.Brands.Queries.GetAllBrands;

namespace Gun16.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<IBrandService, BrandService>();

        services.AddScoped<CreateBrandCommandHandler>();

        services.AddScoped<GetAllBrandsQueryHandler>();

        return services;
    }
}
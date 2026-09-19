using Gun16.Application.Interfaces;
using Gun16.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gun16.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}
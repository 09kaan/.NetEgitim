using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;

namespace Gun16.Application.Features.Products.Queries.GetByIdWithCategory;

public class GetByIdWithCategoryQueryHandler
{
    public readonly IProductRepository _productRepository;

    public GetByIdWithCategoryQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductWithCategoryDto?> HandleAsync(GetByIdWithCategoryQuery query)
    {
        Product? product = await _productRepository.GetByIdAsync(query.Id);

        if (product is null)
        {
            return null;
        }

        ProductWithCategoryDto response = new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
            CategoryName = product.Category.Name
        };

        return response;
    }
}
using Gun16.Application.DTOs;
using Gun16.Domain.Entities;
using Gun16.Application.Interfaces;
using System.Linq;

namespace Gun16.Application.Features.Products.Queries.GetAllWithCategory;

public class GetAllWithCategoryQueryHandler 
{
    private readonly IProductRepository _productRepository;

    public GetAllWithCategoryQueryHandler (IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<List<ProductWithCategoryDto>> HandleAsync(GetAllWithCategoryQuery query)
    {
        List<Product> products =
            await _productRepository.GetAllAsync();

        List<ProductWithCategoryDto> result = products
            .Select(product => new ProductWithCategoryDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name
            })
            .ToList();

        return result;
    }
}   
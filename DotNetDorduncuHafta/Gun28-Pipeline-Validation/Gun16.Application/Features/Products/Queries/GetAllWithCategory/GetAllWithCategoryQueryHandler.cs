using Gun16.Application.DTOs;
using Gun16.Domain.Entities;
using Gun16.Application.Interfaces;
using System.Linq;
using MediatR;

namespace Gun16.Application.Features.Products.Queries.GetAllWithCategory;

public class GetAllWithCategoryQueryHandler : IRequestHandler<GetAllWithCategoryQuery, List<ProductWithCategoryDto>>
{
    private readonly IProductRepository _productRepository;

    public GetAllWithCategoryQueryHandler (IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<List<ProductWithCategoryDto>> Handle(GetAllWithCategoryQuery query, CancellationToken cancellationToken)
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
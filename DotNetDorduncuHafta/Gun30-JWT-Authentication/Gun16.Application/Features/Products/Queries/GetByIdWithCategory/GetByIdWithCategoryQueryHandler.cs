using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Application.Features.Products.Queries.GetByIdWithCategory;

public class GetByIdWithCategoryQueryHandler : IRequestHandler<GetByIdWithCategoryQuery, Result<ProductWithCategoryDto>>
{
    private readonly IProductRepository _productRepository;

    public GetByIdWithCategoryQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Result<ProductWithCategoryDto>> Handle(GetByIdWithCategoryQuery query, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(query.Id, cancellationToken);

        if (product is null)
        {
            return Result<ProductWithCategoryDto>.Failure(ProductErrors.NotFound(query.Id));
        }

        ProductWithCategoryDto response = new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
            CategoryName = product.Category.Name
        };

        return Result<ProductWithCategoryDto>.Success(response);
    }
}
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Gun16.Application.DTOs;
using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductResponseDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateProductCommandHandler (IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<ProductResponseDto>> Handle (CreateProductCommand command , CancellationToken cancellationToken)
    {
        bool categoryExists = await _categoryRepository.ExistsAsync(command.CategoryId, cancellationToken);

        if (!categoryExists)
        {
            return Result<ProductResponseDto>.Failure(CategoryErrors.NotFound(command.CategoryId));
        }
        Product product = new();
        product.Name = command.Name;
        product.CategoryId = command.CategoryId;

        product.ChangePrice(command.Price);

        Product savedProduct = await _productRepository.AddAsync(product, cancellationToken);

        
        ProductResponseDto response = new();
        response.Id = savedProduct.Id;
        response.Name = savedProduct.Name;
        response.Price = savedProduct.Price;
        response.CategoryId = savedProduct.CategoryId;
        response.CategoryName = savedProduct.Category?.Name;

        return Result<ProductResponseDto>.Success(response);
    }
}
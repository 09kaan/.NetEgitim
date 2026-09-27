using Gun16.Application.Interfaces;
using Gun16.Application.DTOs;
using Gun16.Domain.Entities;
using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductResponseDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository) 
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<ProductResponseDto>> Handle(UpdateProductCommand command , CancellationToken cancellationToken)
    {

        Product? product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);

        if (product is null)
        {
            return Result<ProductResponseDto>.Failure(ProductErrors.NotFound(command.Id));
        }

        bool categoryExists = await _categoryRepository.ExistsAsync(command.CategoryId, cancellationToken);

        if (!categoryExists)
        {
            return Result<ProductResponseDto>.Failure(CategoryErrors.NotFound(command.CategoryId));
        }

        product.Name = command.Name;

        product.ChangePrice(command.Price);

        product.CategoryId = command.CategoryId;

        Product updatedProduct = await _productRepository.UpdateAsync(product, cancellationToken);

        ProductResponseDto response = new();

        response.Id = updatedProduct.Id;
        response.Name = updatedProduct.Name;
        response.Price = updatedProduct.Price;
        response.CategoryId = updatedProduct.CategoryId;
        response.CategoryName = updatedProduct.Category?.Name;

        return Result<ProductResponseDto>.Success(response);

    }
}
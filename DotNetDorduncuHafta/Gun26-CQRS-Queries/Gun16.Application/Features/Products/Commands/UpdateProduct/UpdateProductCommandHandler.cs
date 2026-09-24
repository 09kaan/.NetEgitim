using Gun16.Application.Interfaces;
using Gun16.Application.DTOs;
using Gun16.Domain.Entities;

namespace Gun16.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository) 
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ProductResponseDto?> HandleAsync(UpdateProductCommand command)
    {

        Product? product = await _productRepository.GetByIdAsync(command.Id);

        if (product is null)
        {
            return null;
        }

        bool categoryExists = await _categoryRepository.ExistsAsync(command.CategoryId);

        if (!categoryExists)
        {
            return null;
        }

        product.Name = command.Name;

        product.ChangePrice(command.Price);

        product.CategoryId = command.CategoryId;

        Product updatedProduct = await _productRepository.UpdateAsync(product);

        ProductResponseDto response = new();

        response.Id = updatedProduct.Id;
        response.Name = updatedProduct.Name;
        response.Price = updatedProduct.Price;
        response.CategoryId = updatedProduct.CategoryId;
        response.CategoryName = updatedProduct.Category?.Name;

        return response;

    }
}
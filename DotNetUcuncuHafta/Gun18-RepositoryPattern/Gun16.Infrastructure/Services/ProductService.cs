using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Gun16.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gun16.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _productRepository;

    public ProductService(AppDbContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public async Task<Product?> CreateAsync(CreateProductDto dto)
    {
        bool categoryExists =
            await _context.Categories.AnyAsync(
                category => category.Id == dto.CategoryId
            );

        if (!categoryExists)
        {
            return null;
        }

        Product product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return product;
    }
    public async Task<List<ProductWithCategoryDto>> GetAllWithCategoryAsync()
    {
        List<Product> products = await _productRepository.GetAllAsync();

        List<ProductWithCategoryDto> productDtos = products
            .Select(product => new ProductWithCategoryDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name
            })
            .ToList();

        return productDtos;
    }
   public async Task<ProductWithCategoryDto?> GetByIdWithCategoryAsync(int id)
    {
        Product? product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {
            return null;
        }

        return new ProductWithCategoryDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
            CategoryName = product.Category.Name
        };
    }
}
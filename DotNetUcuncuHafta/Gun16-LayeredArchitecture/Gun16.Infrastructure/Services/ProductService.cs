using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Gun16.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gun16.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
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
        List<ProductWithCategoryDto> products =
            await _context.Products
                .Select(product => new ProductWithCategoryDto
                {
                    Id = product.Id,

                    Name = product.Name,

                    Price = product.Price,

                    CategoryId = product.CategoryId,

                    CategoryName = product.Category.Name
                })
                .ToListAsync();

        return products;
    }
    public async Task<ProductWithCategoryDto?> GetByIdWithCategoryAsync(int id)
    {
        ProductWithCategoryDto? product =
            await _context.Products
                .Where(item => item.Id == id)
                .Select(item => new ProductWithCategoryDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category.Name
                })
                .FirstOrDefaultAsync();

        return product;
    }
}
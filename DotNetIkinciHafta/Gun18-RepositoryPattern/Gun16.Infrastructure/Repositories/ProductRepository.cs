using Gun16.Application.Interfaces;
using Gun16.Infrastructure.Data;
using Gun16.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gun16.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(product => product.Category)
            .FirstOrDefaultAsync(product => product.Id == id);
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(product => product.Category)
            .ToListAsync();
    }
}
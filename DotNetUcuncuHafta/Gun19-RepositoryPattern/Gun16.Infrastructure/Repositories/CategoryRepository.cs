using Gun16.Application.Interfaces;
using Gun16.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gun16.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        // Verilen ID'ye sahip en az bir kategori var mı kontrol et.
        return await _context.Categories.AnyAsync(
            category => category.Id == id
        );
    }
}
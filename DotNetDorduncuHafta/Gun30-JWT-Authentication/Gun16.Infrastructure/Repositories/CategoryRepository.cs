using Gun16.Application.Interfaces;
using Gun16.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Gun16.Domain.Entities;

namespace Gun16.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Categories.AnyAsync(category => category.Id == id, cancellationToken);
    }
    
    public async Task<List<Category>> GetAllAsync()
    {
        // Categories tablosundaki bütün kategorileri
        // asenkron olarak listeye çevir.
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category> AddAsync(Category category)
    {
        // Category nesnesini EF Core'a eklenecek olarak bildir.
        _context.Categories.Add(category);

        // Değişikliği SQL Server'a kaydet.
        await _context.SaveChangesAsync();

        // SQL Server'ın ID verdiği Category nesnesini geri döndür.
        return category;
    }
}
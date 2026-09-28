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
    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Include(product => product.Category)
            .FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
    }
    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Include(product => product.Category)
            .ToListAsync(cancellationToken);
    }
    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        // Product nesnesini Products koleksiyonuna ekle
        await _context.Products.AddAsync(product, cancellationToken);

        // Değişikliği SQL Server'a kaydet
        await _context.SaveChangesAsync(cancellationToken);

        // ID'si oluşmuş Product nesnesini geri döndür
        return product;
    }
    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        // Product nesnesini güncellenecek olarak işaretle
        _context.Products.Update(product);

        // Değişikliği SQL Server'a kaydet
        await _context.SaveChangesAsync(cancellationToken);

        // Güncellenmiş ürünü geri döndür       
        return product;
    }
    public async Task DeleteAsync(Product product, CancellationToken cancellationToken = default)
    {
        // Gönderilen Product nesnesini Products tablosundan silinecek olarak işaretle.
        _context.Products.Remove(product);

        // Silme değişikliğini SQL Server'a kaydet.
        await _context.SaveChangesAsync(cancellationToken);
    }
}
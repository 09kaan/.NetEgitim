/*
Listeleme: `ToListAsync()`

Tek kayıt bulma: `FirstOrDefaultAsync()`

Ekleme: `Add()` + `SaveChangesAsync()`

Güncelleme: Property değiştir + `SaveChangesAsync()`

Silme: `Remove()` + `SaveChangesAsync()`
*/
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)        //CategoryService için AppDbContext ver 
    {
        _context = context;
    }

    public Task<List<Category>> GetAllAsync()
    {
        return _context.Categories.ToListAsync();
    }
    
    public async Task<Category> CreateAsync( CreateCategoryDto dto)
    {
        Category category = new Category
        {
            // DTO'dan kategori adını aktar.
            Name = dto.Name
        };

        // Yeni kategoriyi EF Core'a eklenmek üzere hazırla.
        _context.Categories.Add(category);

        // SQLite'a kaydedilmesini bekle.
        await _context.SaveChangesAsync();

        return category;
    }
}

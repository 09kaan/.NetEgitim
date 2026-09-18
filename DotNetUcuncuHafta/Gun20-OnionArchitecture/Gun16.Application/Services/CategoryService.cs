/*
Listeleme: `ToListAsync()`

Tek kayıt bulma: `FirstOrDefaultAsync()`

Ekleme: `Add()` + `SaveChangesAsync()`

Güncelleme: Property değiştir + `SaveChangesAsync()`

Silme: `Remove()` + `SaveChangesAsync()`
*/
using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;

namespace Gun16.Application.Services;

public class CategoryService : ICategoryService
{
    // Kategori veritabanı işlemlerini repository üzerinden yap.
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(
        ICategoryRepository categoryRepository)
    {
        // Constructor’dan gelen repository’yi field’a aktar.
        _categoryRepository = categoryRepository;
    }

    public Task<List<Category>> GetAllAsync()
    {
        // Kategori listesini repository üzerinden getir.
        return _categoryRepository.GetAllAsync();
    }
    
    public async Task<Category> CreateAsync( CreateCategoryDto dto)
    {
        Category category = new Category
        {
            // DTO'dan kategori adını aktar.
            Name = dto.Name
        };

        // Hazırlanan Category nesnesini repository üzerinden kaydet.
    return await _categoryRepository.AddAsync(category);
    }
}

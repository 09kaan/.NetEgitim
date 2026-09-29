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

    public async Task<List<CategoryResponseDto>> GetAllAsync()
    {
        // Repository’den Category entity listesini al.
        List<Category> categories = await _categoryRepository.GetAllAsync();

        // Her Category entity’sini CategoryResponseDto’ya dönüştür.
        return categories
        .Select(category => MapToResponseDto(category))
        .ToList();
    }
    
    public async Task<CategoryResponseDto> CreateAsync( CreateCategoryDto dto)
    {
        Category category = new Category
        {
            // DTO'dan kategori adını aktar.
            Name = dto.Name
        };
        Category createdCategory = await _categoryRepository.AddAsync(category);

        // Hazırlanan Category nesnesini repository üzerinden kaydet.
        return MapToResponseDto(createdCategory);
    }
    private static CategoryResponseDto MapToResponseDto(Category category)
    {
        CategoryResponseDto response = new();

        response.Id = category.Id;
        response.Name = category.Name;

        return response;
    }
}

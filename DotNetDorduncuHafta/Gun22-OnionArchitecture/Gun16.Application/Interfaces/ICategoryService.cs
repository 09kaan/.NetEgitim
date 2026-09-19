using Gun16.Application.DTOs;

namespace Gun16.Application.Interfaces;

public interface ICategoryService
{
    // Bütün kategorileri asenkron olarak getir.
    Task<List<CategoryResponseDto>> GetAllAsync();

    // DTO'dan yeni kategori oluştur ve kaydedilen kategoriyi döndür.
    Task<CategoryResponseDto> CreateAsync(
        CreateCategoryDto dto
    );
}
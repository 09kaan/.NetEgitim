using Gun16.Application.DTOs;
using Gun16.Domain.Entities;

namespace Gun16.Application.Interfaces;

public interface ICategoryService
{
    // Bütün kategorileri asenkron olarak getir.
    Task<List<Category>> GetAllAsync();

    // DTO'dan yeni kategori oluştur ve kaydedilen kategoriyi döndür.
    Task<Category> CreateAsync(
        CreateCategoryDto dto
    );
}
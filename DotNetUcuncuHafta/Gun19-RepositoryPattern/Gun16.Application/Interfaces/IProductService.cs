using Gun16.Application.DTOs;
using Gun16.Domain.Entities;

namespace Gun16.Application.Interfaces;

public interface IProductService
{
    Task<Product?> CreateAsync(CreateProductDto dto);           //? Product id geçersizse null dönsün yani product oluşturulamasın diye var

    Task<List<ProductWithCategoryDto>> GetAllWithCategoryAsync();

    Task<ProductWithCategoryDto?> GetByIdWithCategoryAsync(int id);

    Task<Product?> UpdateAsync(int id, UpdateProductDto dto);

    Task<bool> DeleteAsync(int id); 
}
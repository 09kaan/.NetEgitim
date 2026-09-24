using Gun16.Domain.Entities;

namespace Gun16.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);

    Task<List<Product>> GetAllAsync();

    Task<Product> AddAsync(Product product);

    Task<Product> UpdateAsync(Product product);

    Task DeleteAsync(Product product);
}

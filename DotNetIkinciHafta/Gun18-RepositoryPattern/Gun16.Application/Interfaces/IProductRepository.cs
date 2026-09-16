using Gun16.Domain.Entities;

namespace Gun16.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);

    Task<List<Product>> GetAllAsync();
}

using Gun16.Domain.Entities;
namespace Gun16.Application.Interfaces;

public interface ICategoryRepository
{
    Task<bool> ExistsAsync(int id);

    Task<List<Category>> GetAllAsync();

    Task<Category> AddAsync(Category category);
}
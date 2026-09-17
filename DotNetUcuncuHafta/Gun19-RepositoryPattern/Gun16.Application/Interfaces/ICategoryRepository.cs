namespace Gun16.Application.Interfaces;

public interface ICategoryRepository
{
    Task<bool> ExistsAsync(int id);
}
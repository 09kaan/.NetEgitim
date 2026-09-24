using Gun16.Domain.Entities;

namespace Gun16.Application.Interfaces;


public interface IBrandRepository {

    Task<Brand> AddAsync(Brand brand);

    Task<List<Brand>> GetAllAsync();
}
using Gun16.Domain.Entities;

namespace Gun16.Application.Interfaces;


public interface IBrandRepository {

    Task<Brand> AddAsync(Brand brand, CancellationToken cancellationToken = default);
    Task<List<Brand>> GetAllAsync(CancellationToken cancellationToken = default);
}
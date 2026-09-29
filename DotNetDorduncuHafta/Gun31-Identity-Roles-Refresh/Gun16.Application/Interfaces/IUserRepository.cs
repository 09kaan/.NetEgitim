using Gun16.Domain.Entities;

namespace Gun16.Application.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user, CancellationToken cancellationToken = default);
    Task<User?> GetByUserNameAsync (string userName, CancellationToken cancellationToken = default);
}
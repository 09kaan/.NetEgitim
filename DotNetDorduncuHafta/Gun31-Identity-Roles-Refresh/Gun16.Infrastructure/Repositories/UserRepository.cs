using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Gun16.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gun16.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context ;

    public UserRepository (AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddAsync (User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task<User?> GetByUserNameAsync (string userName, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName, cancellationToken);
        
    }
}
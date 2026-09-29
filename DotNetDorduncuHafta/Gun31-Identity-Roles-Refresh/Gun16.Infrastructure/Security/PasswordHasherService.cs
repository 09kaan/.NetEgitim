using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Gun16.Infrastructure.Security;

public class PasswordHasherService : IPasswordHasherService
{
    private readonly PasswordHasher<User> _passwordHasher;

    public PasswordHasherService()
    {
        _passwordHasher = new();
    }
    public string HashPassword(User user, string password)
    {
        return _passwordHasher.HashPassword(user, password);
    }

    public bool VerifyPassword(User user, string passwordHash, string providedPassword)
    {
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, passwordHash, providedPassword);

        if (result == PasswordVerificationResult.Failed)
        {
            return false;
        }
        return true;
    }
}
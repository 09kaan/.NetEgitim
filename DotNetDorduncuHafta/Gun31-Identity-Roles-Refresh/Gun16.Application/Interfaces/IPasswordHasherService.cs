using Gun16.Domain.Entities;

namespace Gun16.Application.Interfaces;

public interface IPasswordHasherService
{
    string HashPassword (User user, string password);
    bool VerifyPassword (User user, string passwordHash, string providedPassword);
}
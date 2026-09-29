using Gun16.Application.DTOs;

namespace Gun16.Application.Interfaces;

public interface ITokenService 
{
    AuthResponseDto CreateToken(string userId, string userName);
}
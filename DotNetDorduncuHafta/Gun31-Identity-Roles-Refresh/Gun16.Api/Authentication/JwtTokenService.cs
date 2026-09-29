using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Gun16.Api.Authentication;

public class JwtTokenService : ITokenService
{
    private readonly JwtOptions _options;

    public JwtTokenService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public AuthResponseDto CreateToken(string userId, string userName)
    {
        DateTime expiresAtUtc = DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes);

        Claim[] claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        SymmetricSecurityKey securityKey = new(
            Encoding.UTF8.GetBytes(_options.Key)
        );

        SigningCredentials credentials = new(
            securityKey,
            SecurityAlgorithms.HmacSha256
        );

        JwtSecurityToken token = new(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: expiresAtUtc,
            signingCredentials: credentials
        );

        string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            ExpiresAtUtc = expiresAtUtc
        };
    }
}
using System.Security.Claims;
using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gun16.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;

    public AuthController(
        IConfiguration configuration,
        ITokenService tokenService)
    {
        _configuration = configuration;
        _tokenService = tokenService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<AuthResponseDto> Login(LoginRequestDto dto)
    {
        string? demoUserName = _configuration["DemoUser:Username"];
        string? demoPassword = _configuration["DemoUser:Password"];

        if (string.IsNullOrWhiteSpace(demoUserName) ||
            string.IsNullOrWhiteSpace(demoPassword))
        {
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Demo kullanıcı ayarları eksik."
            );
        }

        if (dto.UserName != demoUserName ||
            dto.Password != demoPassword)
        {
            return Unauthorized(new
            {
                Message = "Kullanıcı adı veya parola hatalı."
            });
        }

        AuthResponseDto response =
            _tokenService.CreateToken("1", demoUserName);

        return Ok(response);
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        string? userId =
            User.FindFirstValue(ClaimTypes.NameIdentifier);

        string? userName = User.Identity?.Name;

        return Ok(new
        {
            UserId = userId,
            UserName = userName
        });
    }
}
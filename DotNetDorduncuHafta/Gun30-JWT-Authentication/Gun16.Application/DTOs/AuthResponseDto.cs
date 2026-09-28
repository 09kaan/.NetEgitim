namespace Gun16.Application.DTOs;

public class AuthResponseDto
{
    public string AccessToken {get; set;} = "";
    public DateTime ExpiresAtUtc {get; set;}
}
using Gun16.Application.Common.Results;
using Gun16.Application.DTOs;
using MediatR;
namespace Gun16.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<Result<UserResponseDto>>
{
    public string UserName {get; set;} ="";
    public string Password {get; set; } = "";

}
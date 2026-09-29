using Gun16.Application.Common.Results;
using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using MediatR;

namespace Gun16.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<UserResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;

    public RegisterCommandHandler (IUserRepository userRepository, IPasswordHasherService passwordHasherService)
    {
        _userRepository = userRepository;
        _passwordHasherService = passwordHasherService;
    }

    public async Task<Result<UserResponseDto>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        string normalizedUserName = command.UserName.Trim();
        User? existingUser = await _userRepository.GetByUserNameAsync(normalizedUserName, cancellationToken);
        if(existingUser is not null)
        {
            
            return Result<UserResponseDto>.Failure(UserErrors.AlreadyExists(normalizedUserName));
        }
        User user = new()
        {
        UserName = normalizedUserName,
        Role = "User"
        };
        user.PasswordHash = _passwordHasherService.HashPassword(user, command.Password);
        User savedUser = await _userRepository.AddAsync(user, cancellationToken);
        
        UserResponseDto response = new()
        {
            Id = savedUser.Id,
            UserName = savedUser.UserName,
            Role = savedUser.Role
        };

        return Result<UserResponseDto>.Success(response);
    } 
}
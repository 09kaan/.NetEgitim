using FluentValidation;

namespace Gun16.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator ()
    {
        RuleFor(command => command.UserName)
        .NotEmpty()
        .WithMessage("Kullanıcı adı boş olamaz")
        .Length(3, 50)
        .WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalı");
        
        RuleFor(command => command.Password)
        .NotEmpty()
        .WithMessage("Şifre boş olamaz")
        .Length(8, 100)
        .WithMessage("Şifre 8 ile 100 karakter olmalı")
        .Matches("[A-Z]")
        .WithMessage("Parola en az 1 Büyük harf içermelidir")
        .Matches("[a-z]")
        .WithMessage("Parola en az 1 küçük hartf içermelidir")
        .Matches("[0-9]")
        .WithMessage("Parola en az 1 rakam içermelidir");

    }
}
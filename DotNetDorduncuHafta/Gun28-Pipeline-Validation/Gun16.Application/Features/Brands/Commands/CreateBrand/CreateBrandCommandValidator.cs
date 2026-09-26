using FluentValidation;

namespace Gun16.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(command => command.Name)
        .NotEmpty()
        .WithMessage("Marka adı zorunludur.")
        .Length(2, 100)
        .WithMessage("Marka adı 2-100 karakter olmalıdır.");
     
    }
}
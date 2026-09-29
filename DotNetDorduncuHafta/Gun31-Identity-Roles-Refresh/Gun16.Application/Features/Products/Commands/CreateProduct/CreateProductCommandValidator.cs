using FluentValidation;

namespace Gun16.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Ürün adı zorunludur.")
            .Length(2, 60)
            .WithMessage("Ürün adı 2-60 karakter olmalıdır.");

        RuleFor(command => command.Price)
            .GreaterThan(0)
            .WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

        RuleFor(command => command.CategoryId)
            .GreaterThan(0)
            .WithMessage("Kategori kimliği 0'dan büyük olmalıdır.");
    }
}
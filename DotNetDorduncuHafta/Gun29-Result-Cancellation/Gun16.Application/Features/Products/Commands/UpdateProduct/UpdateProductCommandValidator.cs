using FluentValidation;

namespace Gun16.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Ürün Adı boş olamaz")
            .Length(2, 60)
            .WithMessage("Ürün adı 2-60 karakterden oluşmalıdır.");

        RuleFor(command => command.Id)
            .GreaterThan(0)
            .WithMessage("Ürün Idsi 0 dan büyük olmalı");
         RuleFor(command => command.Price)
            .GreaterThan(0)
            .WithMessage("Ürün Price 0 dan büyük olmalı");
         RuleFor(command => command.CategoryId)
            .GreaterThan(0)
            .WithMessage("Ürün CategoryIdsi 0 dan büyük olmalı");
    }








}
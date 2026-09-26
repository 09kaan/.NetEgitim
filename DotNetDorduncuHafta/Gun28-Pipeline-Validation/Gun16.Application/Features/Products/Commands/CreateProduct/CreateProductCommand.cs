using Gun16.Application.DTOs;
using MediatR;

namespace Gun16.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ProductResponseDto?>
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}
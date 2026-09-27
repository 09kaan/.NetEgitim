using Gun16.Application.DTOs;
using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Result<ProductResponseDto>>
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}
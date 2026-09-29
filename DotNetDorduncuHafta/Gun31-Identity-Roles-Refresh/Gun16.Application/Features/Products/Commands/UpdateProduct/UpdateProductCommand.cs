using Gun16.Application.DTOs;
using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand  : IRequest<Result<ProductResponseDto>>
{
    public int Id {get; set;}
    public string Name {get; set;} = "";
    public decimal Price {get; set;}
    public int CategoryId {get; set;}
}
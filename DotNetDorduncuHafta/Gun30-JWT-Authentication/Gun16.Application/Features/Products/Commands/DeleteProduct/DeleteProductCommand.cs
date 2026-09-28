using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Result<bool>>
{
    public int Id {get; set; }
}
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<bool>>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository) 
    {
        _productRepository = productRepository;
    } 

    public async Task<Result<bool>> Handle(DeleteProductCommand command , CancellationToken cancellationToken)
    {

        Product? product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);

        if(product is null)
        {
            return Result<bool>.Failure(ProductErrors.NotFound(command.Id));
        }

        await _productRepository.DeleteAsync(product, cancellationToken);

        return Result<bool>.Success(true);
    }



}
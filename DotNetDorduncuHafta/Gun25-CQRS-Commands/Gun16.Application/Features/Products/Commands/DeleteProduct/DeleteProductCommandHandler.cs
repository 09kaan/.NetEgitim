using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;

namespace Gun16.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository) 
    {
        _productRepository = productRepository;
    } 

    public async Task<bool> HandleAsync(DeleteProductCommand command)
    {

        Product? product = await _productRepository.GetByIdAsync(command.Id);

        if(product is null)
        {
            return false;
        }

        await _productRepository.DeleteAsync(product);

        return true;
    }



}
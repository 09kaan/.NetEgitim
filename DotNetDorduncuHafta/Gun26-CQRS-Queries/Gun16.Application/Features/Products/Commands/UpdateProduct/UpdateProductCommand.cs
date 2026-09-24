

namespace Gun16.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand
{
    public int Id {get; set;}
    public string Name {get; set;} = "";
    public decimal Price {get; set;}
    public int CategoryId {get; set;}
}
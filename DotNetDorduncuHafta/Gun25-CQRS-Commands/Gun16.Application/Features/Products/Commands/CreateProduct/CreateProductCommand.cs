
namespace Gun16.Application.Features.Products.Commands.CreateProduct;


public class CreateProductCommand{

    public string Name {get; set; } = "";
    public decimal Price {get; set; }
    public int CategoryId {get; set; }
}
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Klavye",
            Price = 850
        },
        new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 450
        }
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        // Products listesini 200 OK ile döndür.
        return Ok(Products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // Products listesinde Id değeri,
        // URL'den gelen id değerine eşit olan ilk ürünü bul.
        Product? product = Products.FirstOrDefault(
            item => item.Id == id
        );

        // Ürün bulunamadıysa 404 döndür.
        if (product is null)
        {
            return NotFound(new
            {
                Message = "Ürün bulunamadı."
            });
        }

        // Bulunan ürünü 200 OK ile döndür.
        return Ok(product);
    }
    [HttpGet("expensive")]
    public IActionResult GetExpensive()
    {
        List<Product> expensiveProducts = Products
            .Where(item => item.Price >= 500)
            .ToList();

        // Listeyi 200 OK ile döndür.
        return Ok(expensiveProducts);
    }
}
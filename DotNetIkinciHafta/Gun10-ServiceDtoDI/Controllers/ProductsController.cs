using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {   
        List<Product> products = _service.GetAll();
        // Products listesini 200 OK ile döndür.
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // Service'in GetById metodunu çağır.
        // URL'den gelen id değerini metoda gönder.
        Product? product = _service.GetById(id);

        // Service null döndürdüyse ürün bulunamamıştır.
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
        List<Product> expensiveProducts = _service
            .GetAll()
            .Where(item => item.Price >= 500)
            .ToList();

        // Listeyi 200 OK ile döndür.
        return Ok(expensiveProducts);
    }
    [HttpPost]
    public IActionResult Create(CreateProductDto dto)
    {   
        // dto.Name boş, null veya yalnızca boşluklardan mı oluşuyor?
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest(new
            {
                Message = "Ürün adı boş olamaz."
            });
        }
        // DTO'yu service'in Create metoduna gönder.
        // Service'in döndürdüğü ürünü product değişkenine koy.

        // dto.Price sıfır veya negatif mi?
        if (dto.Price <= 0)
        {
            return BadRequest(new
            {
                Message = "Fiyat pozitif olmalıdır."
            });
        }

        Product product = _service.Create(dto);

        // İlk testte ürünü 200 OK ile döndür.
        return CreatedAtAction(
        nameof(GetById),
        new { id = product.Id },
        product
    );
    }
}
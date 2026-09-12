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

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        // Ürün adı boş mu?
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest(new
            {
                Message = "Ürün adı boş olamaz."
            });
        }

        // Fiyat sıfır veya negatif mi?
        if (dto.Price <= 0)
        {
            return BadRequest(new
            {
                Message = "Fiyat pozitif olmalıdır."
            });
        }

        // DTO'yu ProductService'e gönder.
        Product? product = await _service.CreateAsync(dto);

        // Service null döndürdüyse kategori bulunamadı.
        if (product is null)
        {
            return NotFound(new
            {
                Message = "Kategori bulunamadı."
            });
        }

        return StatusCode(
            StatusCodes.Status201Created,
            product
        );
    }
    [HttpGet("with-category")]
    public async Task<IActionResult> GetAllWithCategory()
    {
        List<ProductWithCategoryDto> products = await _service.GetAllWithCategoryAsync();

        return Ok(products);
    }
}
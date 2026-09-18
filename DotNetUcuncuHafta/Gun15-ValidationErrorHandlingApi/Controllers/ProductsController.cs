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
        
        // DTO'yu ProductService'e gönder.
        Product? product = await _service.CreateAsync(dto);

        // Service null döndürdüyse kategori bulunamadı.
        if (product is null)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: "Kategori bulunamadı.",
                detail: "Gönderilen CategoryId veritabanında mevcut değil."
            );
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
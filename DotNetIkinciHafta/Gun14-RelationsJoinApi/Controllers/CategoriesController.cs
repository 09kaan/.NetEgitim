using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Category> categories = await _service.GetAllAsync();

        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto dto)
    {
        // Kategori adı boş, null veya yalnızca boşluk mu?
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest(new
            {
                Message = "Kategori adı boş olamaz."
            });
        }

        // DTO'yu service'e gönder ve oluşturulan kategoriyi al.
        Category category =
            await _service.CreateAsync(dto);

        // Oluşturulan kategoriyi 201 Created ile döndür.
        return StatusCode(
            StatusCodes.Status201Created,
            category
        );
    }
}   
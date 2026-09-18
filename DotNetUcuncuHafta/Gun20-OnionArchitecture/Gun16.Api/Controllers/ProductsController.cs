using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gun16.Api.Controllers;

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
    [HttpGet("{id:int}/with-category")]
    public async Task<IActionResult> GetByIdWithCategory(int id)
    {
        ProductWithCategoryDto? product =
            await _service.GetByIdWithCategoryAsync(id);

        if (product is null)
        {
            return NotFound(new
            {
                Message = "Ürün bulunamadı."
            });
        }

        return Ok(product);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto dto)
    {
        // Service'e ürün ID'sini ve yeni değerleri gönder.
        Product? product =
            await _service.UpdateAsync(id, dto);

        // Service null döndürürse ürün veya kategori bulunamamıştır.
        if (product is null)
        {
            return NotFound(new
            {
                Message = "Ürün veya kategori bulunamadı."
            });
        }

        // Güncellenmiş ürünü 200 OK ile döndür.
        // Entity'nin Category ilişkisini doğrudan JSON'a verme.
        // Yalnızca istemciye gerekli olan alanları döndür.
        return Ok(new
        {
            // Güncellenen ürünün kimliği
            Id = product.Id,

            // Güncel ürün adı
            Name = product.Name,

            // Güncel fiyat
            Price = product.Price,

            // Güncel kategori kimliği
            CategoryId = product.CategoryId
        });
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Service üzerinden ID'ye sahip ürünü silmeyi dene.
        bool deleted =
            await _service.DeleteAsync(id);

        // Silme başarısızsa ürün bulunamamıştır.
        if (deleted is false)
        {
            return NotFound(new
            {
                Message = "Ürün bulunamadı."
            });
        }

        // Silme başarılı; cevap gövdesi olmadan HTTP 204 döndür.
        return NoContent();
    }    
}
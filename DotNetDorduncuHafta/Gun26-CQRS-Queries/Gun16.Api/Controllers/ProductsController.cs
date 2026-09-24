using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Gun16.Application.Features.Products.Commands.CreateProduct;
using Gun16.Application.Features.Products.Commands.UpdateProduct;
using Gun16.Application.Features.Products.Commands.DeleteProduct;
using Gun16.Application.Features.Products.Queries.GetAllWithCategory;
using Gun16.Application.Features.Products.Queries.GetByIdWithCategory;
namespace Gun16.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly CreateProductCommandHandler _createProductCommandHandler;
    private readonly UpdateProductCommandHandler _updateProductCommandHandler;
    private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
    private readonly GetAllWithCategoryQueryHandler _getAllWithCategoryQueryHandler;
    private readonly GetByIdWithCategoryQueryHandler _getByIdWithCategoryQueryHandler;

    public ProductsController(CreateProductCommandHandler createProductCommandHandler
    , UpdateProductCommandHandler updateProductCommandHandler, DeleteProductCommandHandler deleteProductCommandHandler
    , GetAllWithCategoryQueryHandler getAllWithCategoryQueryHandler, GetByIdWithCategoryQueryHandler getByIdWithCategoryQueryHandler)
    {
    
        _createProductCommandHandler = createProductCommandHandler;
        _updateProductCommandHandler = updateProductCommandHandler;
        _deleteProductCommandHandler = deleteProductCommandHandler;
        _getAllWithCategoryQueryHandler = getAllWithCategoryQueryHandler;
        _getByIdWithCategoryQueryHandler = getByIdWithCategoryQueryHandler;

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        
        CreateProductCommand command = new()
    {
        Name = dto.Name,
        Price = dto.Price,
        CategoryId = dto.CategoryId
    };

    ProductResponseDto? product =
        await _createProductCommandHandler.HandleAsync(command);
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
        GetAllWithCategoryQuery query = new();
        List<ProductWithCategoryDto> products = await _getAllWithCategoryQueryHandler.HandleAsync(query);

        return Ok(products);
    }
    [HttpGet("{id:int}/with-category")]
    public async Task<IActionResult> GetByIdWithCategory(int id)
    {   
        GetByIdWithCategoryQuery query = new() {Id = id};
        ProductWithCategoryDto? product = await _getByIdWithCategoryQueryHandler.HandleAsync(query);
        
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

        UpdateProductCommand command = new();
        command.Id = id;
        command.Name = dto.Name;
        command.Price = dto.Price;
        command.CategoryId = dto.CategoryId;

        
        // Service'e ürün ID'sini ve yeni değerleri gönder.
        ProductResponseDto? product = await _updateProductCommandHandler.HandleAsync(command);

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
        // Handler üzerinden ID'ye sahip ürünü silmeyi dene.
        DeleteProductCommand command = new();
        command.Id = id;

        bool deleted = await _deleteProductCommandHandler.HandleAsync(command);

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
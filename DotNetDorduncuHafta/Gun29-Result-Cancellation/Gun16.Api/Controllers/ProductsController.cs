using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Gun16.Application.Features.Products.Commands.CreateProduct;
using Gun16.Application.Features.Products.Commands.UpdateProduct;
using Gun16.Application.Features.Products.Commands.DeleteProduct;
using Gun16.Application.Features.Products.Queries.GetAllWithCategory;
using Gun16.Application.Features.Products.Queries.GetByIdWithCategory;
using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController( ISender sender)
    {
        _sender = sender;

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto, CancellationToken cancellationToken)
    {
        
        CreateProductCommand command = new()
    {
        Name = dto.Name,
        Price = dto.Price,
        CategoryId = dto.CategoryId
    };

    Result<ProductResponseDto> result = await _sender.Send(command, cancellationToken);
        // Service null döndürdüyse kategori bulunamadı.
        if (result.IsFailure)
        {
            return NotFound(new
            {
                Code = result.Error.Code,
                Message = result.Error.Message
            });
        }

        return StatusCode(StatusCodes.Status201Created, result.Value);
    }
    [HttpGet("with-category")]
    public async Task<IActionResult> GetAllWithCategory(CancellationToken cancellationToken)
    {   
        GetAllWithCategoryQuery query = new();
        List<ProductWithCategoryDto> products = await _sender.Send(query, cancellationToken);

        return Ok(products);
    }
    [HttpGet("{id:int}/with-category")]
    public async Task<IActionResult> GetByIdWithCategory(int id, CancellationToken cancellationToken)
    {   
        GetByIdWithCategoryQuery query = new() {Id = id};
        Result<ProductWithCategoryDto> result = await _sender.Send(query, cancellationToken);
        
        if (result.IsFailure)
        {
            return NotFound(new
            {   
                Code = result.Error.Code,
                Message = result.Error.Message
            });
        }

        return Ok(result.Value);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto dto, CancellationToken cancellationToken)
    {   

        UpdateProductCommand command = new();
        command.Id = id;
        command.Name = dto.Name;
        command.Price = dto.Price;
        command.CategoryId = dto.CategoryId;

        
        // Service'e ürün ID'sini ve yeni değerleri gönder.
        Result<ProductResponseDto> result = await _sender.Send(command, cancellationToken);

        // Service null döndürürse ürün veya kategori bulunamamıştır.
        if (result.IsFailure)
        {
            return NotFound(new
            {
                Code = result.Error.Code,
                Message = result.Error.Message
            });
        }

        // Güncellenmiş ürünü 200 OK ile döndür.
        // Entity'nin Category ilişkisini doğrudan JSON'a verme.
        // Yalnızca istemciye gerekli olan alanları döndür.
        return Ok(result.Value);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        // Handler üzerinden ID'ye sahip ürünü silmeyi dene.
        DeleteProductCommand command = new();
        command.Id = id;

        Result<bool> result = await _sender.Send(command, cancellationToken);

        // Silme başarısızsa ürün bulunamamıştır.
        if (result.IsFailure)
        {
            return NotFound(new
            {
                Code = result.Error.Code,
                Message = result.Error.Message
            });
        }

        // Silme başarılı; cevap gövdesi olmadan HTTP 204 döndür.
        return NoContent();
    }    
}
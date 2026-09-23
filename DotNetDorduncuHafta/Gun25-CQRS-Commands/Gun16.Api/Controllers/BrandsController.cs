using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gun16.Application.Features.Brands.Commands.CreateBrand;
using Gun16.Application.Features.Brands.Queries.GetAllBrands;

namespace Gun16.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly CreateBrandCommandHandler _createBrandCommandHandler;
    private readonly GetAllBrandsQueryHandler _getAllBrandsQueryHandler;

    public BrandsController (CreateBrandCommandHandler createBrandCommandHandler, GetAllBrandsQueryHandler getAllBrandsQueryHandler)
    {
        _createBrandCommandHandler = createBrandCommandHandler;
        _getAllBrandsQueryHandler = getAllBrandsQueryHandler;
    }
    [HttpGet]
    public async Task<ActionResult<List<BrandResponseDto>>> GetAllAsync()
    {
        GetAllBrandsQuery query = new();
        
        List<BrandResponseDto> brands = await _getAllBrandsQueryHandler.HandleAsync(query);

        return Ok(brands);
    }

    [HttpPost]
    public async Task<ActionResult<BrandResponseDto>> CreateAsync(
        [FromBody] CreateBrandDto dto)
    {
       CreateBrandCommand command = new();
       command.Name = dto.Name;
       BrandResponseDto response = await _createBrandCommandHandler.HandleAsync(command);

        return StatusCode(
            StatusCodes.Status201Created,
            response
        );
    }
}
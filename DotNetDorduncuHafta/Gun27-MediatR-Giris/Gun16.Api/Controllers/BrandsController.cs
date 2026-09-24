using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gun16.Application.Features.Brands.Commands.CreateBrand;
using Gun16.Application.Features.Brands.Queries.GetAllBrands;
using MediatR;

namespace Gun16.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly ISender _sender;

    public BrandsController (ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<ActionResult<List<BrandResponseDto>>> GetAllAsync()
    {
        GetAllBrandsQuery query = new();
        
        List<BrandResponseDto> brands = await _sender.Send(query);

        return Ok(brands);
    }

    [HttpPost]
    public async Task<ActionResult<BrandResponseDto>> CreateAsync(
        [FromBody] CreateBrandDto dto)
    {
       CreateBrandCommand command = new();
       command.Name = dto.Name;
       BrandResponseDto response = await _sender.Send(command);

        return StatusCode(
            StatusCodes.Status201Created,
            response
        );
    }
}
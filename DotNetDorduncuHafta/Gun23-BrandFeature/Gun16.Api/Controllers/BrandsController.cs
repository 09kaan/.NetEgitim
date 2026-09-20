using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gun16.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BrandResponseDto>>> GetAllAsync()
    {
        List<BrandResponseDto> brands =
            await _brandService.GetAllAsync();

        return Ok(brands);
    }

    [HttpPost]
    public async Task<ActionResult<BrandResponseDto>> CreateAsync(
        [FromBody] CreateBrandDto dto)
    {
        BrandResponseDto response =
            await _brandService.CreateAsync(dto);

        return StatusCode(
            StatusCodes.Status201Created,
            response
        );
    }
}
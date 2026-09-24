using Gun16.Application.DTOs;

namespace Gun16.Application.Interfaces;


public interface IBrandService
{

    Task<BrandResponseDto> CreateAsync(CreateBrandDto dto);

    Task<List<BrandResponseDto>> GetAllAsync();
} 
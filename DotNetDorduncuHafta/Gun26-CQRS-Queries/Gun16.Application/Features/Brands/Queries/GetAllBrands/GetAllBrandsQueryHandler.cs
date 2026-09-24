using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;

namespace Gun16.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryHandler
{
    private readonly IBrandRepository _brandRepository;

    public GetAllBrandsQueryHandler(
        IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<List<BrandResponseDto>> HandleAsync(
        GetAllBrandsQuery query)
    {
        // TODO: Repository'den List<Brand> getir.
        List<Brand> brands = await _brandRepository.GetAllAsync();
        // TODO: Brand listesini BrandResponseDto listesine dönüştür.
        List<BrandResponseDto> response = brands.Select(brand => new BrandResponseDto
        {
            Id = brand.Id,
            Name = brand.Name
        })
        .ToList();
        // TODO: DTO listesini döndür.
        return response;
    }
}
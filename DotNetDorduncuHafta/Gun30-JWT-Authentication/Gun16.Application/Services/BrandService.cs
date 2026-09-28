using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;

namespace Gun16.Application.Services;
// TODO 1: DTO, Interfaces ve Domain Entities namespace'lerini ekle.

// TODO 2: Namespace: Gun16.Application.Services

// TODO 3: BrandService sınıfı IBrandService'i uygulasın.

// TODO 4: IBrandRepository tipinde private readonly field oluştur.

// TODO 5: Constructor üzerinden IBrandRepository alıp field'a ata.
public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    
    public BrandService (IBrandRepository brandRepository)
    {

        _brandRepository = brandRepository;

    }
    // TODO: Yeni bir Brand entity oluştur.
// TODO: Entity'nin Name değerini dto.Name'den al.
// TODO: Entity'yi repository'nin AddAsync metoduna gönder ve sonucu bekle.
// TODO: Kaydedilen Brand'in Id ve Name değerleriyle BrandResponseDto oluştur.
// TODO: DTO'yu döndür.
    public async Task<BrandResponseDto> CreateAsync(CreateBrandDto dto)
    {

        Brand brand = new();

        brand.Name = dto.Name;
        
        Brand savedBrand = await _brandRepository.AddAsync(brand);

        BrandResponseDto response = new();
        response.Id = savedBrand.Id;
        response.Name = savedBrand.Name;

        return response;

    } 

// TODO: Repository'den bütün Brand entity'lerini asenkron getir.
// TODO: Her Brand'i Id ve Name taşıyan BrandResponseDto'ya dönüştür.
// TODO: Sonucu liste hâline getirip döndür.
    public async Task<List<BrandResponseDto>> GetAllAsync()
    {
        List<Brand> brands = await _brandRepository.GetAllAsync();

        List<BrandResponseDto> responseDtos = brands
            .Select(brand => new BrandResponseDto
            {
                Id = brand.Id,
                Name = brand.Name
            })
            .ToList();

        return responseDtos;
    }







}
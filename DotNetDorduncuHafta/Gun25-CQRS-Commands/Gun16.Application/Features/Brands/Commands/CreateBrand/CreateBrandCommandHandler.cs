using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;

namespace Gun16.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler
{

    private readonly IBrandRepository _brandRepository;


    public CreateBrandCommandHandler(IBrandRepository brandRepository)
    {

        _brandRepository = brandRepository;

    }

    public async Task<BrandResponseDto> HandleAsync( CreateBrandCommand command)
    {
        // TODO 1: Brand tipinde brand adlı yeni entity oluştur.

        Brand brand = new ();
    // TODO 2: brand.Name değerini command.Name değerinden al.

        brand.Name = command.Name;
    // TODO 3: _brandRepository.AddAsync ile entity'yi kaydet.
    // Dönen sonucu savedBrand adlı Brand değişkenine al.
        Brand savedBrand = await _brandRepository.AddAsync(brand);

    // TODO 4: BrandResponseDto tipinde response adlı nesne oluştur
        BrandResponseDto response = new();

    // TODO 5: response.Id değerini savedBrand.Id'den al.
        response.Id = savedBrand.Id;

    // TODO 6: response.Name değerini savedBrand.Name'den al.
        response.Name = savedBrand.Name;

        return response;
    }






}
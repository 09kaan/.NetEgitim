using Gun16.Application.DTOs;
using MediatR;

namespace Gun16.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand : IRequest<BrandResponseDto>
{
    // TODO: Marka oluşturmak için gereken veriyi taşıyan,
    // null başlamayan public string property yaz.
    public string Name { get; set; } = "";
}
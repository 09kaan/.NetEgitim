using Gun16.Application.DTOs;
using MediatR;

namespace Gun16.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQuery : IRequest<List<BrandResponseDto>>
{
}
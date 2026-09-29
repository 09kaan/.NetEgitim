using Gun16.Application.DTOs;
using MediatR;

namespace Gun16.Application.Features.Products.Queries.GetAllWithCategory;

public class GetAllWithCategoryQuery : IRequest<List<ProductWithCategoryDto>>
{
}
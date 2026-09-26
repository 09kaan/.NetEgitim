using Gun16.Application.DTOs;
using MediatR;

namespace Gun16.Application.Features.Products.Queries.GetByIdWithCategory;

public class GetByIdWithCategoryQuery : IRequest<ProductWithCategoryDto?>
{
    public int Id {get; set;}
}
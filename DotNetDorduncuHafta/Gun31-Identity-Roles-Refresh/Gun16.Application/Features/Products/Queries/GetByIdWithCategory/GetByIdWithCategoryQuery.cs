using Gun16.Application.DTOs;
using MediatR;
using Gun16.Application.Common.Results;

namespace Gun16.Application.Features.Products.Queries.GetByIdWithCategory;

public class GetByIdWithCategoryQuery : IRequest<Result<ProductWithCategoryDto>>
{
    public int Id {get; set;}
}
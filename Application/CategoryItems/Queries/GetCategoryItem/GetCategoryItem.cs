using Application.Categories.DTO;
using Application.Categories.Queries.GetCategories;
using Application.CategoryItems.DTO;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.GetCategoryItem;

public record GetCategoryItemQuery(int Id) : IRequest<CategoryItemDto>;

public class GetCategoryItemQueryHandler : IRequestHandler<GetCategoryItemQuery, CategoryItemDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryItemDto> Handle(GetCategoryItemQuery request, CancellationToken cancellationToken)
    {
        var categoryItem = await _context.CategoryItems.FindAsync(request.Id);

        return _mapper.Map<CategoryItemDto>(categoryItem);
    }
}

using Application.Categories.DTO;
using Application.Categories.Queries.GetCategories;
using Application.CategoryItems.DTO;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CategoryItems.Queries.GetCategoryItems;

public record GetCategoryItemsQuery : IRequest<IEnumerable<CategoryItemDto>>;

public class GetCategoryItemsHandler : IRequestHandler<GetCategoryItemsQuery, IEnumerable<CategoryItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryItemsHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryItemDto>> Handle(GetCategoryItemsQuery request, CancellationToken cancellationToken)
    {
        var categoryItems = await _context.CategoryItems.OrderBy(c => c.Name).ToListAsync();

        return _mapper.Map<IEnumerable<CategoryItemDto>>(categoryItems);
    }
}

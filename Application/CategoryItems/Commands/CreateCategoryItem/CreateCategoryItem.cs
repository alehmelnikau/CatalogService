using Application.Categories.Commands.CreateCategory;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.CategoryItems.Commands.CreateCategoryItem;

public class CreateCategoryItemCommand : IRequest<int>
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public decimal Price { get; set; }

    public int Amount { get; set; }

    public int CategoryId { get; set; }
}

public class CreateCategoryItemCommandHandler : IRequestHandler<CreateCategoryItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryItemCommand command, CancellationToken cancellationToken)
    {
        var entity = new CategoryItem
        {
            Name = command.Name,
            Description = command.Description,
            Image = command.Image,
            Price = command.Price,
            Amount = command.Amount,
            CategoryId = command.CategoryId,
        };

        _context.CategoryItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

using Application.Categories.Commands.UpdateCategory;
using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;

namespace Application.CategoryItems.Commands.UpdateCategoryItem;

public record UpdateCategoryItemCommand : IRequest
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public decimal Price { get; set; }

    public int Amount { get; set; }

    public int CategoryId { get; set; }
}

public class UpdateCategoryItemCommandHandler : IRequestHandler<UpdateCategoryItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCategoryItemCommand command, CancellationToken cancellationToken)
    {
        var entity = await _context.CategoryItems
            .FindAsync(new object[] { command.Id }, cancellationToken);

        Guard.Against.NotFound(command.Id, entity);

        entity.Name = command.Name;
        entity.Description = command.Description;
        entity.Image = command.Image;
        entity.Price = command.Price;
        entity.Amount = command.Amount;
        entity.CategoryId = command.CategoryId;

        await _context.SaveChangesAsync(cancellationToken);

        return new Unit();
    }
}

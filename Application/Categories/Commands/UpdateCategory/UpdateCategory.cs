using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;

namespace Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; init; }
    public string? Image { get; init; }
    public int? ParentCategoryId { get; init; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { command.Id }, cancellationToken);

        Guard.Against.NotFound(command.Id, entity);

        entity.Name = command.Name;
        entity.Image = command.Image;
        entity.ParentCategoryId = command.ParentCategoryId;

        await _context.SaveChangesAsync(cancellationToken);

        return new Unit();
    }
}

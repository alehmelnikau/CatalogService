using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;

namespace Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { command.Id }, cancellationToken);

        Guard.Against.NotFound(command.Id, entity, "id");

        _context.Categories.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new Unit();
    }
}

using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;

namespace Application.CategoryItems.Commands.DeleteCategoryItem;

public record DeleteCategoryItemCommand(int Id) : IRequest;

public class DeleteCategoryItemCommandHandler : IRequestHandler<DeleteCategoryItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCategoryItemCommand command, CancellationToken cancellationToken)
    {
        var entity = await _context.CategoryItems
            .FindAsync(new object[] { command.Id }, cancellationToken);

        Guard.Against.NotFound(command.Id, entity, "id");

        _context.CategoryItems.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new Unit();
    }
}

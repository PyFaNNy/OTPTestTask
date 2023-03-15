using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Exceptions;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Application.Aggregates.Position.Commands.DeletePosition;

public class DeletePositionCommandHandler : AbstractRequestHandler, IRequestHandler<DeletePositionCommand, Unit>
{
    public DeletePositionCommandHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
    {
    }

    public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        var position = await DbContext.Positions
            .Where(x => x.Id == request.PositionId)
            .Include(x => x.Employees)
            .FirstOrDefaultAsync(cancellationToken);

        if (position == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Position), request.PositionId);
        }

        if (position.Employees.Count != 0)
        {
            throw new DeleteEntityException(nameof(Domain.Entities.Position), request.PositionId);
        }

        DbContext.Positions.Remove(position);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
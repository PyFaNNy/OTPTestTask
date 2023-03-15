using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Exceptions;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Application.Aggregates.Position.Commands.UpdatePosition;

public class UpdatePositionCommandHandler : AbstractRequestHandler, IRequestHandler<UpdatePositionCommand, Unit>
{
    public UpdatePositionCommandHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(mediator,
        dbContext, mapper)
    {
    }

    public async Task<Unit> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        var position = await DbContext.Positions
            .Where(x => x.Id == request.PositionId)
            .FirstOrDefaultAsync(cancellationToken);

        if (position == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Employee), request.PositionId);
        }

        Mapper.Map(request, position);
        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
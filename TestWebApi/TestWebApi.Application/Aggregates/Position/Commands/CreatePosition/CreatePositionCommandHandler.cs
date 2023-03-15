using AutoMapper;
using MediatR;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Application.Aggregates.Position.Commands.CreatePosition;

public class CreatePositionCommandHandler  : AbstractRequestHandler, IRequestHandler<CreatePositionCommand, Unit>
{
    public CreatePositionCommandHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
    {
    }

    public async Task<Unit> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        var position = Mapper.Map<Domain.Entities.Position>(request);
        await DbContext.Positions.AddAsync(position, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
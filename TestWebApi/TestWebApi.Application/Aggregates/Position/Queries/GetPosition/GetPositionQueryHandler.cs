using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Exceptions;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Application.Aggregates.Position.Queries.GetPosition;

public class GetPositionQueryHandler : AbstractRequestHandler,
    IRequestHandler<GetPositionQuery, Position>
{
    public GetPositionQueryHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
    {
    }

    public async Task<Position> Handle(GetPositionQuery request, CancellationToken cancellationToken)
    {
        var position =await DbContext.Positions
            .Where(x => x.Id == request.PositionId)
            .ProjectTo<Position>(this.Mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        if (position == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Position), request.PositionId);
        }
            
        return position;
    }
}
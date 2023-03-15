using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Interfaces;
using TestWebApi.Application.Models;

namespace TestWebApi.Application.Aggregates.Position.Queries.GetPositions;

public class GetPositionsQueryHandler : AbstractRequestHandler,
    IRequestHandler<GetPositionsQuery, PaginatedList<Position>>
{
    public GetPositionsQueryHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(mediator,
        dbContext, mapper)
    {
    }

    public async Task<PaginatedList<Position>> Handle(GetPositionsQuery request,
        CancellationToken cancellationToken)
    {
        var positions = DbContext.Positions
            .ProjectTo<Position>(Mapper.ConfigurationProvider);

        var paginatedList =
            await PaginatedList<Position>.CreateAsync(positions, request.PageIndex, request.PageSize);

        return paginatedList;
    }
}
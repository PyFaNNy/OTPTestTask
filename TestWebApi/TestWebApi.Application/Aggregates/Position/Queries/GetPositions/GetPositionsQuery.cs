using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Models;

namespace TestWebApi.Application.Aggregates.Position.Queries.GetPositions;

public class GetPositionsQuery : GetPaginatedListBaseQuery<PaginatedList<Position>>
{
    public GetPositionsQuery(int? pageIndex, int? pageSize) : base(pageIndex, pageSize)
    {
    }
}
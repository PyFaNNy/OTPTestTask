using MediatR;

namespace TestWebApi.Application.Aggregates.Position.Queries.GetPosition;

public class GetPositionQuery : IRequest<Position>
{
    public int PositionId { get; set; }
}
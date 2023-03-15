using MediatR;

namespace TestWebApi.Application.Aggregates.Position.Commands.DeletePosition;

public class DeletePositionCommand : IRequest<Unit>
{
    /// <summary>
    /// Position Id
    /// </summary>
    public int PositionId { get; set; }
}
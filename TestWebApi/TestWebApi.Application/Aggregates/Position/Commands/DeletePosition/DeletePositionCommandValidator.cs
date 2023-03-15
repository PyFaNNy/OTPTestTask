using FluentValidation;

namespace TestWebApi.Application.Aggregates.Position.Commands.DeletePosition;

public class DeletePositionCommandValidator : AbstractValidator<DeletePositionCommand>
{
    public DeletePositionCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .GreaterThan(0);
    }
}
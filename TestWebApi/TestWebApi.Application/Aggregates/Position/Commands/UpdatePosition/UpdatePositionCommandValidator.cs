using FluentValidation;

namespace TestWebApi.Application.Aggregates.Position.Commands.UpdatePosition;

public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
{
    public UpdatePositionCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .GreaterThan(0);
        
        RuleFor(x => x.Grade)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(15);
        
        RuleFor(x => x.Name)
            .NotNull()
            .Matches(@"^([А-Я][а-яё]{1,64}|[A-Z][a-z]{1,64})");
    }
}
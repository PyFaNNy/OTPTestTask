using FluentValidation;

namespace TestWebApi.Application.Aggregates.Position.Commands.CreatePosition;

public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
{
    public CreatePositionCommandValidator()
    {
        RuleFor(x => x.Grade)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(15);
        
        RuleFor(x => x.Name)
            .NotNull()
            .Matches(@"^([А-Я][а-яё]{1,64}|[A-Z][a-z]{1,64})");
    }
}
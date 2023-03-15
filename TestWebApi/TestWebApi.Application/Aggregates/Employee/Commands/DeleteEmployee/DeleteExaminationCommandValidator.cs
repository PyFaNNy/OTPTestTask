using FluentValidation;

namespace TestWebApi.Application.Aggregates.Employee.Commands.DeleteEmployee
{
    public class DeleteExaminationCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteExaminationCommandValidator()
        {
            RuleFor(x => x.EmployeeId)
                .GreaterThan(0);
        }
    }
}

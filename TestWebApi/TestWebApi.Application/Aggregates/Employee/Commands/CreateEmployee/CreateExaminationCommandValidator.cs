using FluentValidation;

namespace TestWebApi.Application.Aggregates.Employee.Commands.CreateEmployee
{
    public class CreateExaminationCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateExaminationCommandValidator()
        {
            RuleFor(x => x.LastName)
                .NotNull()
                .Matches(@"^([А-Я]{1}[а-яё]{1,32}|[A-Z]{1}[a-z]{1,32})$");
            
            RuleFor(x => x.FirstName)
                .NotNull()
                .Matches(@"^([А-Я]{1}[а-яё]{1,32}|[A-Z]{1}[a-z]{1,32})$");
            
            RuleFor(x => x.MiddleName)
                .NotNull()
                .Matches(@"^([А-Я]{1}[а-яё]{1,32}|[A-Z]{1}[a-z]{1,32})$");
            
            RuleFor(x => x.DateBirth)
                .Must(ValidateDate);
        }
        
        /// <summary>
        /// Date of birth validation that the employee is over 16 years of age
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private bool ValidateDate(DateTime date)
        {
            return date.Year < DateTime.Now.Year-16;
        }
    }
}

using MediatR;

namespace TestWebApi.Application.Aggregates.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public int EmployeeId { get; set; }
    }
}

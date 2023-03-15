using MediatR;

namespace TestWebApi.Application.Aggregates.Employee.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<Employee>
    {
        public int EmployeeId { get; set; }
    }
}
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Models;

namespace TestWebApi.Application.Aggregates.Employee.Queries.GetEmployees;

public class GetEmployeesQuery : GetPaginatedListBaseQuery<PaginatedList<Employee>>
{
    public GetEmployeesQuery(int? pageIndex, int? pageSize) : base(pageIndex, pageSize)
    {
    }
}
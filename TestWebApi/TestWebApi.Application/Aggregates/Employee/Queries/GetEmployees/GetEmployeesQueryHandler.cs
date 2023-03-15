using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Interfaces;
using TestWebApi.Application.Models;

namespace TestWebApi.Application.Aggregates.Employee.Queries.GetEmployees;

public class GetEmployeesQueryHandler : AbstractRequestHandler,
    IRequestHandler<GetEmployeesQuery, PaginatedList<Employee>>
{
    public GetEmployeesQueryHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(mediator,
        dbContext, mapper)
    {
    }

    public async Task<PaginatedList<Employee>> Handle(GetEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var employees = DbContext.Employees
            .ProjectTo<Employee>(Mapper.ConfigurationProvider);

        var paginatedList =
            await PaginatedList<Employee>.CreateAsync(employees, request.PageIndex, request.PageSize);

        return paginatedList;
    }
}
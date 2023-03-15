using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Exceptions;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Application.Aggregates.Employee.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler : AbstractRequestHandler,
        IRequestHandler<GetEmployeeQuery, Employee>
    {
        public GetEmployeeQueryHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee =await DbContext.Employees
                .Where(x => x.Id == request.EmployeeId)
                .ProjectTo<Employee>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Employee), request.EmployeeId);
            }
            
            return employee;
        }
    }
}
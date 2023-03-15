using AutoMapper;
using MediatR;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Application.Aggregates.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : AbstractRequestHandler, IRequestHandler<CreateEmployeeCommand, Unit>
    {
        public CreateEmployeeCommandHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(
            mediator, dbContext, mapper)
        {
        }
        
        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = Mapper.Map<Domain.Entities.Employee>(request);
            await DbContext.Employees.AddAsync(employee, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
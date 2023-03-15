using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Application.Abstractions;
using TestWebApi.Application.Exceptions;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Application.Aggregates.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : AbstractRequestHandler, IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        public DeleteEmployeeCommandHandler(IMediator mediator, IAppDbContext dbContext, IMapper mapper) : base(
            mediator, dbContext, mapper)
        {
        }
        
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await DbContext.Employees
                .Where(x => x.Id == request.EmployeeId)
                .FirstOrDefaultAsync(cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Employee), request.EmployeeId);
            }

            DbContext.Employees.Remove(employee);
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
} 
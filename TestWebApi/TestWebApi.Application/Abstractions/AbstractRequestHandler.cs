using AutoMapper;
using MediatR;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Application.Abstractions;

public abstract class AbstractRequestHandler
{
    protected IMediator Mediator
    {
        get;
    }

    protected IAppDbContext DbContext
    {
        get;
    }

    protected IMapper Mapper
    {
        get;
    }

    public AbstractRequestHandler(
        IMediator mediator,
        IAppDbContext dbContext,
        IMapper mapper)
    {
        Mediator = mediator;
        DbContext = dbContext;
        Mapper = mapper;
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => this._mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();

    /// <summary>
    /// Constructor
    /// </summary>
    protected BaseController()
        : base()
    {
    }
}
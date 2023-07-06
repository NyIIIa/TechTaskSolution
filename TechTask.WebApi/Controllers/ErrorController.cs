using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechTask.WebApi.Domain.Exceptions.Generic;

namespace TechTask.WebApi.Controllers;

[Route("/error")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is ConflictDataException conflictException)
        {
            return Problem(statusCode: 409, title: conflictException.Message);
        }
        else if (exception is NotFoundException notFoundException)
        {
            return Problem(statusCode: 404, title: notFoundException.Message);
        }
        else
        {
            return BadRequest(exception?.Message);
        }
    }
}
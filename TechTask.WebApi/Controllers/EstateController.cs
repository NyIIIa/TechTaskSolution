using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechTask.WebApi.Application.Estate.Commands.Add;
using TechTask.WebApi.Application.Estate.Commands.Update;
using TechTask.WebApi.Application.Estate.Queries.GetAll;

namespace TechTask.WebApi.Controllers;

[ApiController]
[Route("api/estate")]
public class EstateController : ControllerBase
{
    private readonly ISender _sender;

    public EstateController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(AddEstateRequest addEstateRequest)
    {
        var addEstateResponse = await _sender.Send(addEstateRequest);

        return Ok(addEstateResponse);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateEstateRequest updateEstateRequest)
    {
        var updateEstateResponse = await _sender.Send(updateEstateRequest);

        return Ok(updateEstateResponse);
    }
    
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var getAllEstatesResponse = await _sender.Send(new GetAllEstatesRequest());

        return Ok(getAllEstatesResponse);
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechTask.WebApi.Application.User.Commands.Add;
using TechTask.WebApi.Application.User.Commands.Update;
using TechTask.WebApi.Application.User.Queries.GetAll;
using TechTask.WebApi.Application.User.Queries.GetById;

namespace TechTask.WebApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(AddUserRequest addUserRequest)
    {
        var addUserResponse = await _sender.Send(addUserRequest);

        return Ok(addUserRequest);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateUserRequest updateUserRequest)
    {
        var updateUserResponse = await _sender.Send(updateUserRequest);

        return Ok(updateUserResponse);
    }
    
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var getAllUsersResponse = await _sender.Send(new GetAllUsersRequest());

        return Ok(getAllUsersResponse);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetById([FromQuery] GetUserByIdRequest getUserByIdRequest)
    {
        var getUserByIdResponse = await _sender.Send(getUserByIdRequest);

        return Ok(getUserByIdResponse);
    }
}
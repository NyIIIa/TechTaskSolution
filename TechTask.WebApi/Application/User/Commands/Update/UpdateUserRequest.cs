using MediatR;

namespace TechTask.WebApi.Application.User.Commands.Update;

public record UpdateUserRequest(
    string CurrentName,
    string NewName,
    string NewEmail,
    string NewPhoneNumber) : IRequest<UpdateUserResponse>;
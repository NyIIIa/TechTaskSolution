using MediatR;

namespace TechTask.WebApi.Application.User.Commands.Add;

public record AddUserRequest(
    string Name,
    string EmailAddress,
    string PhoneNumber) : IRequest<AddUserResponse>;
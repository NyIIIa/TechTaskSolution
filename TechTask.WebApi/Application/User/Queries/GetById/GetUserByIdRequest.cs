using MediatR;

namespace TechTask.WebApi.Application.User.Queries.GetById;

public record GetUserByIdRequest(int UserId) : IRequest<GetUserByIdResponse>;
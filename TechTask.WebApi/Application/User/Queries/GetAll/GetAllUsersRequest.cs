using MediatR;

namespace TechTask.WebApi.Application.User.Queries.GetAll;

public record GetAllUsersRequest() : IRequest<IEnumerable<GetAllUsersResponse>>;
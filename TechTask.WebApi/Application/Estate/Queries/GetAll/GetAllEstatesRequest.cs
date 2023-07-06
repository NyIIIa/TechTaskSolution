using MediatR;

namespace TechTask.WebApi.Application.Estate.Queries.GetAll;

public record GetAllEstatesRequest() : IRequest<IEnumerable<GetAllEstatesResponse>>;
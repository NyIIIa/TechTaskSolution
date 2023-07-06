using MediatR;

namespace TechTask.WebApi.Application.Estate.Queries.GetById;

public record GetEstateByIdRequest(int EstateId) : IRequest<GetEstateByIdResponse>;
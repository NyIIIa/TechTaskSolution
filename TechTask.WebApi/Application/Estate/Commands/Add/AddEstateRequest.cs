using MediatR;
using TechTask.WebApi.Application.User.Commands.Add;
using TechTask.WebApi.Domain.Enums;

namespace TechTask.WebApi.Application.Estate.Commands.Add;

public record AddEstateRequest
    (string Title, 
    string UserName,
    EstateType Type,
    DateTime DateOfPurchase,
    decimal InitialPrice,
    Period PeriodOfPriceReduction) : IRequest<AddEstateResponse>;
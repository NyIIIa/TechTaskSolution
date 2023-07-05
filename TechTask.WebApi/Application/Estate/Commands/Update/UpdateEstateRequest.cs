using MediatR;
using TechTask.WebApi.Domain.Enums;

namespace TechTask.WebApi.Application.Estate.Commands.Update;

public record UpdateEstateRequest(
    string CurrentTitle,
    string NewTitle,
    EstateType NewType,
    DateTime NewDateOfPurchase,
    decimal NewInitialPrice,
    Period NewPeriodOfPriceReduction) : IRequest<UpdateEstateResponse>;
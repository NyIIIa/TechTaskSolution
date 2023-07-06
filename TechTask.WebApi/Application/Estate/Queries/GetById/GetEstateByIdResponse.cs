using TechTask.WebApi.Domain.Enums;

namespace TechTask.WebApi.Application.Estate.Queries.GetById;

public record GetEstateByIdResponse(
    int Id,
    string Title,
    EstateType Type,
    DateTime DateOfPurchase,
    decimal InitialPrice,
    Period PeriodOfPriceReduction,
    decimal PriceReduction,
    decimal CurrentPrice,
    string UserName);
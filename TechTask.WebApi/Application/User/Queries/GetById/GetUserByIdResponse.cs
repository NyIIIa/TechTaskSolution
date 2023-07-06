namespace TechTask.WebApi.Application.User.Queries.GetById;

public record GetUserByIdResponse(
    int Id,
    string Name,
    string EmailAddress,
    string PhoneNumber,
    decimal InitialSumOfEstates,
    decimal CurrentSumOfEstates);
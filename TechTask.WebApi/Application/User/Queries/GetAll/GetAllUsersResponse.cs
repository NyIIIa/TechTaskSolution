namespace TechTask.WebApi.Application.User.Queries.GetAll;

public record GetAllUsersResponse(
    int Id,
    string Name,
    string EmailAddress,
    string PhoneNumber,
    decimal InitialSumOfEstates,
    decimal CurrentSumOfEstates);
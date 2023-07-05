namespace TechTask.WebApi.Infrastructure.Interfaces;

public interface IUserEstateManager
{
    Task UpdateUserSumEstatesAsync(string userName);
}
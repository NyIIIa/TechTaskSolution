using Microsoft.EntityFrameworkCore;
using TechTask.WebApi.Domain.Exceptions.User;
using TechTask.WebApi.Infrastructure.Interfaces;
using TechTask.WebApi.Persistence;

namespace TechTask.WebApi.Infrastructure.Services;

public class UserEstateManager : IUserEstateManager
{
    private readonly ApplicationDbContext _dbContext;

    public UserEstateManager(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task UpdateUserSumEstatesAsync(string userName, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.Estates)
            .FirstOrDefaultAsync(u => u.Name == userName, cancellationToken);
        if (user is null)
        {
            // throw new Exception("Impossible calculate user's initial and current sum of estates, because user name was not found");
            throw new UserNameNotFoundException("Impossible calculate user's initial and current sum of estates, because user name was not found");
        }
        
        user.InitialSumOfEstates = CalculateInitialSumOfEstates(user.Estates);
        user.CurrentSumOfEstates = CalculateCurrentSumOfEstates(user.Estates);

        _dbContext.Users.Update(user);
        Console.WriteLine(user.InitialSumOfEstates);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    private decimal CalculateInitialSumOfEstates(IEnumerable<Domain.Entities.Estate> estates)
    {
        decimal initialSumOfEstates = 0;

        foreach (var estate in estates)
        {
            if (estate.InitialPrice != 0)
            {
                initialSumOfEstates += estate.InitialPrice;
            }
        }

        return initialSumOfEstates;
    }
    
    private decimal CalculateCurrentSumOfEstates(IEnumerable<Domain.Entities.Estate> estates)
    {
        decimal currentSumOfEstates = 0;

        foreach (var estate in estates)
        {
            if (estate.CurrentPrice != 0)
            {
                currentSumOfEstates += estate.CurrentPrice;
            }
        }

        return currentSumOfEstates;
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using TechTask.WebApi.Persistence;

namespace TechTask.WebApi.Application.User.Queries.GetAll;

public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<GetAllUsersResponse>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetAllUsersCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<GetAllUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        //the best way to use AutoMapper 
        var getAllUsersResponse = await _dbContext.Users
            .Select(u => new GetAllUsersResponse
                (u.Id, u.Name, u.EmailAddress, u.PhoneNumber, u.InitialSumOfEstates, u.CurrentSumOfEstates))
            .ToListAsync(cancellationToken);

        return getAllUsersResponse;
    }
}
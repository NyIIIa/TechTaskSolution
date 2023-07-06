using MediatR;
using Microsoft.EntityFrameworkCore;
using TechTask.WebApi.Persistence;

namespace TechTask.WebApi.Application.User.Queries.GetById;

public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly ApplicationDbContext _dbContext;

    public GetUserByIdCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
        return new GetUserByIdResponse(
            user.Id, 
            user.Name, 
            user.EmailAddress, 
            user.PhoneNumber, 
            user.InitialSumOfEstates, 
            user.CurrentSumOfEstates);
    }
}
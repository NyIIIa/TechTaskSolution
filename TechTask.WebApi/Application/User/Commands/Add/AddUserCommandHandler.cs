using MediatR;
using Microsoft.EntityFrameworkCore;
using TechTask.WebApi.Persistence;

namespace TechTask.WebApi.Application.User.Commands.Add;

public class AddUserCommandHandler : IRequestHandler<AddUserRequest, AddUserResponse>
{
    private readonly ApplicationDbContext _dbContext;

    public AddUserCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var isUserExists = await _dbContext.Users.AnyAsync(u => u.Name == request.Name, cancellationToken);

        if (isUserExists)
        {
            throw new Exception("The user with specified name already exists!");
        }

        var user = new Domain.Entities.User()
        {
            Name = request.Name,
            EmailAddress = request.EmailAddress,
            PhoneNumber = request.PhoneNumber
        };

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new AddUserResponse(user.Id);
    }
}
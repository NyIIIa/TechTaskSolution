using MediatR;
using Microsoft.EntityFrameworkCore;
using TechTask.WebApi.Domain.Exceptions.User;
using TechTask.WebApi.Persistence;

namespace TechTask.WebApi.Application.User.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly ApplicationDbContext _dbContext;

    public UpdateUserCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var isUserWithNewNameExists = await _dbContext.Users.AnyAsync(u => u.Name == request.NewName, cancellationToken);

        if (isUserWithNewNameExists)
        {
            // throw new Exception("The user with new name already exists! Please choose another name!");
            throw new ConflictUserNameException("The user with new name already exists! Please choose another name!");
        }
        
        var userFromDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == request.CurrentName, cancellationToken);

        if (userFromDb is null)
        {
            // throw new Exception("The user with current title was not found!");
            throw new UserNameNotFoundException("The user with current title was not found!");
        }

        userFromDb.Name = request.NewName;
        userFromDb.EmailAddress = request.NewEmail;
        userFromDb.PhoneNumber = request.NewPhoneNumber;

        _dbContext.Users.Update(userFromDb);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateUserResponse(true);
    }
}
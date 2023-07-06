using TechTask.WebApi.Domain.Exceptions.Generic;

namespace TechTask.WebApi.Domain.Exceptions.User;

public class UserNameNotFoundException : NotFoundException
{
    public UserNameNotFoundException(string message) : base(message) { }
}
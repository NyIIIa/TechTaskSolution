using TechTask.WebApi.Domain.Exceptions.Generic;

namespace TechTask.WebApi.Domain.Exceptions.User;

public class ConflictUserNameException : ConflictDataException
{
    public ConflictUserNameException(string message) : base(message) { }
}
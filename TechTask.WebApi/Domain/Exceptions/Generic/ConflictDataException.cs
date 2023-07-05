namespace TechTask.WebApi.Domain.Exceptions.Generic;

public class ConflictDataException : Exception
{
    protected ConflictDataException(string message) : base(message){}
}
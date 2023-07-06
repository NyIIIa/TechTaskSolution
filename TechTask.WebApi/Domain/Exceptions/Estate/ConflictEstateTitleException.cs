using TechTask.WebApi.Domain.Exceptions.Generic;

namespace TechTask.WebApi.Domain.Exceptions.Estate;

public class ConflictEstateTitleException : ConflictDataException
{
    public ConflictEstateTitleException(string message) : base(message) { }
}
using TechTask.WebApi.Domain.Exceptions.Generic;

namespace TechTask.WebApi.Domain.Exceptions.Estate;

public class EstateTitleNotFoundException : NotFoundException
{
    public EstateTitleNotFoundException(string message) : base(message) { }
}
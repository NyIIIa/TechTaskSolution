using MediatR;
using Microsoft.EntityFrameworkCore;
using TechTask.WebApi.Persistence;

namespace TechTask.WebApi.Application.Estate.Queries.GetById;

public class GetEstateByIdCommandHandler : IRequestHandler<GetEstateByIdRequest, GetEstateByIdResponse>
{
    private readonly ApplicationDbContext _dbContext;

    public GetEstateByIdCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<GetEstateByIdResponse> Handle(GetEstateByIdRequest request, CancellationToken cancellationToken)
    {
        var estate = await _dbContext.Estates
            .Include(e => e.User)
            .FirstOrDefaultAsync(e => e.Id == request.EstateId, cancellationToken);
        
        return new GetEstateByIdResponse(
            estate.Id,
            estate.Title,
            estate.Type,
            estate.DateOfPurchase,
            estate.InitialPrice,
            estate.PeriodOfPriceReduction,
            estate.PriceReduction,
            estate.CurrentPrice,
            estate.User.Name);
    }
}
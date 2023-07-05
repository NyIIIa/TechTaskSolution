using MediatR;
using Microsoft.EntityFrameworkCore;
using TechTask.WebApi.Persistence;

namespace TechTask.WebApi.Application.Estate.Queries.GetAll;

public class GetAllEstatesCommandHandler : IRequestHandler<GetAllEstatesRequest, IEnumerable<GetAllEstatesResponse>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetAllEstatesCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<GetAllEstatesResponse>> Handle(GetAllEstatesRequest request, CancellationToken cancellationToken)
    {
        //the best way to use AutoMapper 
        var getAllEstatesResponse = await _dbContext.Estates
            .Include(e => e.User)
            .Select(e => new GetAllEstatesResponse
            (e.Id, e.Title, e.Type, e.DateOfPurchase,
                e.InitialPrice, e.PeriodOfPriceReduction,
                e.PriceReduction, e.CurrentPrice, e.User.Name)).ToListAsync(cancellationToken);

        return getAllEstatesResponse;
    }
}
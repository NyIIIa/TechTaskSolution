using MediatR;
using Microsoft.EntityFrameworkCore;
using TechTask.WebApi.Domain.Exceptions.Estate;
using TechTask.WebApi.Infrastructure.Interfaces;
using TechTask.WebApi.Persistence;

namespace TechTask.WebApi.Application.Estate.Commands.Update;

public class UpdateEstateCommandHandler : IRequestHandler<UpdateEstateRequest, UpdateEstateResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IUserEstateManager _userEstateManager;

    public UpdateEstateCommandHandler(ApplicationDbContext dbContext, IUserEstateManager userEstateManager)
    {
        _dbContext = dbContext;
        _userEstateManager = userEstateManager;
    }
    
    public async Task<UpdateEstateResponse> Handle(UpdateEstateRequest request, CancellationToken cancellationToken)
    {
        var estateFromDb =
            await _dbContext.Estates
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Title == request.CurrentTitle, cancellationToken);
        if (estateFromDb is null)
        {
            // throw new Exception("The estate with current title doesn't exist!");
            throw new EstateTitleNotFoundException("The estate with current title doesn't exist!");
        }

        var isNewTitleExists = await _dbContext.Estates.AnyAsync(e => e.Title == request.NewTitle, cancellationToken);
        if (isNewTitleExists)
        {
            // throw new Exception("The estate with new title already exist! Please choose another new title!");
            throw new ConflictEstateTitleException("The estate with new title already exist! Please choose another new title!");
        }
        var newEstateCurrentPrice = Domain.Entities.Estate.CalculateCurrentPrice(request.NewInitialPrice,
            request.NewDateOfPurchase, request.NewPeriodOfPriceReduction);
        var newEstatePriceReduction =
            Domain.Entities.Estate.CalculatePriceReduction(request.NewInitialPrice, newEstateCurrentPrice);
        
        estateFromDb.Title = request.NewTitle;
        estateFromDb.Type = request.NewType;
        estateFromDb.DateOfPurchase = request.NewDateOfPurchase;
        estateFromDb.InitialPrice = request.NewInitialPrice;
        estateFromDb.PeriodOfPriceReduction = request.NewPeriodOfPriceReduction;
        estateFromDb.CurrentPrice = newEstateCurrentPrice;
        estateFromDb.PriceReduction = newEstatePriceReduction;

        _dbContext.Estates.Update(estateFromDb);
        await _dbContext.SaveChangesAsync(cancellationToken);

        await _userEstateManager.UpdateUserSumEstatesAsync(estateFromDb.User.Name, cancellationToken);

        return new UpdateEstateResponse(true);
    }
}
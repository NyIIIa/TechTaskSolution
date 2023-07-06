using TechTask.WebApi.Domain.Enums;

namespace TechTask.WebApi.Domain.Entities;

public class Estate
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public EstateType Type { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public decimal InitialPrice { get; set; }
    public Period PeriodOfPriceReduction { get; set; }
    public decimal PriceReduction { get; set; } //calculated  for period
    public decimal CurrentPrice { get; set; }
    public User User { get; set; } = null!;
    
    public static decimal CalculatePriceReduction(decimal initialPrice, decimal currentPrice)
    {
        var priceReduction = initialPrice - currentPrice;
    
        return priceReduction;
    }
    
    public static decimal CalculateCurrentPrice(decimal initialPrice, DateTime dateOfPurchase, Period periodOfPriceReduction)
    {
        var currentDate = DateTime.Now;
        
        var daysOfOwnership = (int)(currentDate - dateOfPurchase).TotalDays;
    
        var periodsCount = daysOfOwnership / (int)periodOfPriceReduction;
        
        var currentPrice = initialPrice - ((int)periodOfPriceReduction * periodsCount);
    
        return currentPrice;
    }
}
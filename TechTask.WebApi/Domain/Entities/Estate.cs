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
}
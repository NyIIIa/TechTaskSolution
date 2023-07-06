using TechTask.Client.Data.Enums;

namespace TechTask.Client.Data;

public class Estate
{
    public int Id { get; set; }
    public string Title { get; set; }
    public EstateType Type { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public decimal InitialPrice { get; set; }
    public Period PeriodOfPriceReduction { get; set; }
    public decimal PriceReduction { get; set; }
    public decimal CurrentPrice { get; set; }
    public string UserName { get; set; }
}
using TechTask.Client.Data.Enums;

namespace TechTask.Client.Dto.Estate.Add;

public class AddEstateRequest
{
    public string Title { get; set; }
    public string UserName { get; set; }
    public EstateType Type { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public decimal InitialPrice { get; set; }
    public Period PeriodOfPriceReduction { get; set; }
}

using TechTask.Client.Data.Enums;

namespace TechTask.Client.Dto.Estate.Update;

public class UpdateEstateRequest
{
    public string CurrentTitle { get; set; }
    public string NewTitle { get; set; }
    public EstateType NewType { get; set; }
    public DateTime NewDateOfPurchase { get; set; }
    public decimal NewInitialPrice { get; set; }
    public Period NewPeriodOfPriceReduction { get; set; }
}
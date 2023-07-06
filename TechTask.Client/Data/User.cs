namespace TechTask.Client.Data;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public decimal InitialSumOfEstates { get; set; }
    public decimal CurrentSumOfEstates { get; set; }
}
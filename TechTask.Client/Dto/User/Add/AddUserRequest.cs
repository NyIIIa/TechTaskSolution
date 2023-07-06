namespace TechTask.Client.Dto.User.Add;

public class AddUserRequest
{
    public string Name { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
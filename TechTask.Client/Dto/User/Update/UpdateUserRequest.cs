namespace TechTask.Client.Dto.User.Update;

public class UpdateUserRequest
{
    public string CurrentName { get; set; }
    public string NewName { get; set; }
    public string NewEmail { get; set; }
    public string NewPhoneNumber { get; set; }
}
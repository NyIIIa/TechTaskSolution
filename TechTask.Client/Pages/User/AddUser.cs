using Microsoft.AspNetCore.Components;
using TechTask.Client.Dto.User.Add;
using TechTask.Client.Services.User;

namespace TechTask.Client.Pages.User;

public partial class AddUser
{
    public AddUserRequest AddUserRequest { get; set; } = new AddUserRequest();
    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    protected async void CreateEmployee()
    {
        await UserService.Add(AddUserRequest);
        NavigationManager.NavigateTo("/users");
    }
    void Cancel()
    {
        NavigationManager.NavigateTo("/users");
    }
}
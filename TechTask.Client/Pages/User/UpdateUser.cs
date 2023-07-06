using Microsoft.AspNetCore.Components;
using TechTask.Client.Dto.User.Update;
using TechTask.Client.Services.User;

namespace TechTask.Client.Pages.User;

public partial class UpdateUser
{
    [Parameter]
    public string Id { get; set; }
    [Inject]
    public IUserService UserService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public UpdateUserRequest UpdateUserRequest { get; set; } = new UpdateUserRequest();
    
    protected async void Update()
    {
        await UserService.Update(UpdateUserRequest);
        NavigationManager.NavigateTo("/users");
    }
    void Cancel()
    {
        NavigationManager.NavigateTo("/users");
    }
    
}
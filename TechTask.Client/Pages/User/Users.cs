using Microsoft.AspNetCore.Components;
using TechTask.Client.Services.User;

namespace TechTask.Client.Pages.User;

public partial class Users
{
    [Inject]
    private IUserService UserService { get; set; }

    public IEnumerable<Data.User> _users { get; set; } = new List<Data.User>();
    
    protected override async Task OnInitializedAsync()
    {
        var users = await UserService.GetAll();

        _users = users;
    }
}
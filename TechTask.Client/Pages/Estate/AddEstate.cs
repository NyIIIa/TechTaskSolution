using Microsoft.AspNetCore.Components;
using TechTask.Client.Dto.Estate.Add;
using TechTask.Client.Services.Estate;

namespace TechTask.Client.Pages.Estate;

public partial class AddEstate
{
    public AddEstateRequest AddEstateRequest { get; set; } = new AddEstateRequest();
    [Inject]
    public IEstateService EstateService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    protected async void CreateEstate()
    {
        await EstateService.Add(AddEstateRequest);
        NavigationManager.NavigateTo("/estates");
    }
    void Cancel()
    {
        NavigationManager.NavigateTo("/estates");
    }
}
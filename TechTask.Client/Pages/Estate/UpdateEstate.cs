using Microsoft.AspNetCore.Components;
using TechTask.Client.Dto.Estate.Update;
using TechTask.Client.Services.Estate;

namespace TechTask.Client.Pages.Estate;

public partial class UpdateEstate
{
    [Parameter]
    public string Id { get; set; }
    [Inject]
    public IEstateService EstateService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public UpdateEstateRequest UpdateEstateRequest { get; set; } = new UpdateEstateRequest();
    
    protected async void Update()
    {
        await EstateService.Update(UpdateEstateRequest);
        NavigationManager.NavigateTo("/estates");
    }
    void Cancel()
    {
        NavigationManager.NavigateTo("/estates");
    }
}
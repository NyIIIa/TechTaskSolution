using Microsoft.AspNetCore.Components;
using TechTask.Client.Services.Estate;

namespace TechTask.Client.Pages.Estate;

public partial class Estates
{
    [Inject]
    private IEstateService EstateService { get; set; }

    public IEnumerable<Data.Estate> _estates { get; set; } = new List<Data.Estate>();
    
    protected override async Task OnInitializedAsync()
    {
        var estates = await EstateService.GetAll();

        _estates = estates;
    }
}
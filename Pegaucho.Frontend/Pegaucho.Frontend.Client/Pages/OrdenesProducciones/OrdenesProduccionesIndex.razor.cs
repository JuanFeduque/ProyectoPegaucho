using Microsoft.AspNetCore.Components;
using Pegaucho.Frontend.Client.Repositories;
using Pegaucho.Shared.Entities;
namespace Pegaucho.Frontend.Client.Pages.OrdenesProducciones;

public partial class OrdenesProduccionesIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;
    protected override async Task OnInitializedAsync()
    {
        var response = await Repository.GetAsync<List<OrdenProduccion>>("api/ordenesproducciones");
    }
}
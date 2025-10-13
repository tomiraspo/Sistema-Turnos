using Turnos.Model.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Turnos.SharedKernel.Interfaces.Services;

namespace Turnos.Web.Pages.Home;

[Authorize]
public partial class Home : ComponentBase
{
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

}

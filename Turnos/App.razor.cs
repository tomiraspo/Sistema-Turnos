using Microsoft.AspNetCore.Components;

namespace Turnos.Web
{
    public partial class App
    {
        [Inject] private NavigationManager NavManager { get; set; }
    }
}

using Turnos.Model.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Turnos.SharedKernel.Interfaces.Services;
using Radzen;

namespace Turnos.Web.Pages.Profesionales;

[Authorize]
public partial class AddProfesionalPage : ComponentBase
{
    [Inject] IProfesionalService ProfesionalService { get; set; }

    IEnumerable<ProfesionalDto> profesionales;

    ProfesionalDto profesionalUpdateDto = new ProfesionalDto();

    void Submit(ProfesionalDto arg)
    {
        ProfesionalService.CreateNewProfesionalAsync(profesionalUpdateDto);
        profesionales = ProfesionalService.GetProfesionales("");
    }

    protected override async Task OnInitializedAsync()
    {
        profesionales = ProfesionalService.GetProfesionales("");
        await base.OnInitializedAsync();
    }

    void Cancel()
    {
        profesionalUpdateDto.Nombre = "";
        profesionalUpdateDto.Matricula = "";
        profesionalUpdateDto.Telefono = "";
        profesionalUpdateDto.Apellido = "";
        profesionalUpdateDto.DNI = "";
        profesionalUpdateDto.Mail = "";
    }

    void EliminarProfesional(int id)
    {
        ProfesionalService.EliminarProfesional(id);
        profesionales = ProfesionalService.GetProfesionales("");
    }

    async Task ShowConfirmationDialog(int id)
    {
        var result = await DialogService.Confirm("Estas seguro?", "Eliminar Profesional", new ConfirmOptions() { OkButtonText = "Si", CancelButtonText = "No" });

        if (result.HasValue && result.Value)
        {
            EliminarProfesional(id);
        }
    }
}

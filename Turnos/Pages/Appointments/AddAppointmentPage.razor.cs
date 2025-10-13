using Turnos.Model.UI;
using Microsoft.AspNetCore.Components;
using Radzen;
using Microsoft.AspNetCore.Authorization;

namespace Turnos.Web.Pages.Appointments;

[Authorize]
public partial class AddAppointmentPage
{
    [Parameter]
    public DateTime Start { get; set; }

    [Parameter]
    public DateTime End { get; set; }

    AppointmentDto model = new AppointmentDto();
    IEnumerable<PacienteDto> pacientes;
    IEnumerable<ProfesionalDto> profesionales;

    protected override void OnParametersSet()
    {
        model.Start = Start;
        model.End = End;
    }

    protected override async Task OnInitializedAsync()
    {
        pacientes = PacientesService.GetPacientes("");
        profesionales = ProfesionalesService.GetProfesionales("");
        await base.OnInitializedAsync();
    }

    void OnSubmit(AppointmentDto model)
    {
        AppointmentService.CreateNewAppointmentAsync(model);
        DialogService.Close(model);
    }

    void OnLoadPacientes(LoadDataArgs args)
    {
        pacientes = PacientesService.GetPacientes(args.Filter);
    }

    void OnLoadProfesionales(LoadDataArgs args)
    {
        profesionales = ProfesionalesService.GetProfesionales(args.Filter);
    }
}

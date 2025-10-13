using Turnos.Model.UI;
using Microsoft.AspNetCore.Components;
using Radzen;
using Microsoft.AspNetCore.Authorization;

namespace Turnos.Web.Pages.Appointments;

[Authorize]
public partial class EditAppointmentPage
{
    [Parameter] public AppointmentDto Appointment { get; set; }

    AppointmentDto model = new AppointmentDto();
    IEnumerable<PacienteDto> pacientes;
    IEnumerable<ProfesionalDto> profesionales;

    protected override void OnParametersSet()
    {
        model = Appointment;
    }

    protected override async Task OnInitializedAsync()
    {
        pacientes = PacientesService.GetPacientes("");
        profesionales = ProfesionalesService.GetProfesionales("");
        await base.OnInitializedAsync();
    }

    void OnSubmit(AppointmentDto model)
    {
        AppointmentService.EditAppointmentAsync(model);
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

    async Task Eliminar(int id)
    {
        AppointmentService.EliminarAppointment(id);
        DialogService.Close(model);
    }
}

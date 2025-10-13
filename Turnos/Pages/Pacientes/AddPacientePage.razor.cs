using Turnos.Model.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using Turnos.SharedKernel.Interfaces.Services;
using Radzen;

namespace Turnos.Web.Pages.Pacientes;

[Authorize]
public partial class AddPacientePage : ComponentBase
{
    [Inject] IPacienteService PacienteService { get; set; }

    IEnumerable<PacienteDto> pacientes;

    public class ObraSocialDto
    {
        public int OSId { get; set; }
        public string OSNombre { get; set; }
    }

    bool pacienteCreado = false;

    PacienteDto pacienteUpdateDto = new PacienteDto();

    List<ObraSocialDto> obraSociales = new List<ObraSocialDto>()
{
        new ObraSocialDto() { OSId = 1, OSNombre = "OSDE" },
        new ObraSocialDto() { OSId = 2, OSNombre = "Swiss Medical" }
    };

    protected override async Task OnInitializedAsync()
    {
        pacientes = PacienteService.GetPacientes("");
        await base.OnInitializedAsync();
    }

    void Submit(PacienteDto arg)
    {
        PacienteService.CreateNewPacienteAsync(pacienteUpdateDto);
        pacientes = PacienteService.GetPacientes("");
    }

    void Cancel()
    {
        pacienteUpdateDto.Nombre = "";
        pacienteUpdateDto.ObraSocial = 0;
        pacienteUpdateDto.Telefono = "";
        pacienteUpdateDto.Apellido = "";
        pacienteUpdateDto.DNI = "";
        pacienteUpdateDto.Domicilio = "";
    }

    void EliminarPaciente(int id)
    {
        PacienteService.EliminarPaciente(id);
        pacientes = PacienteService.GetPacientes("");
    }

    async Task ShowConfirmationDialog(int id)
    {
        var result = await DialogService.Confirm("Estas seguro?", "Eliminar Paciente", new ConfirmOptions() { OkButtonText = "Si", CancelButtonText = "No" });

        if (result.HasValue && result.Value)
        {
            EliminarPaciente(id);
        }
    }
}

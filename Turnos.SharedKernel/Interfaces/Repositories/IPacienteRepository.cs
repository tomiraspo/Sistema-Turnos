using Turnos.Model.UI;

namespace Turnos.SharedKernel.Interfaces.Repositories;

public interface IPacienteRepository
{
    public int CreateNewPacienteAsync(PacienteDto paciente);
    public IEnumerable<PacienteDto> GetPacientes(string query);
    public void EliminarPaciente(int Id);
}

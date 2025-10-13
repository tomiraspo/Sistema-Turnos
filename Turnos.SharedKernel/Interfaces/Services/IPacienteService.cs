using Turnos.Model.UI;

namespace Turnos.SharedKernel.Interfaces.Services
{
    public interface IPacienteService
    {
        public int CreateNewPacienteAsync(PacienteDto appointment);
        public IEnumerable<PacienteDto> GetPacientes(string query);
        public void EliminarPaciente(int Id);

    }
}

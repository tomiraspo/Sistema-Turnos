using Turnos.Model.UI;
using Turnos.SharedKernel.Interfaces.Repositories;
using Turnos.SharedKernel.Interfaces.Services;

namespace Turnos.Application.Services;

public class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _repository;

    public PacienteService(IPacienteRepository repository)
    {
        _repository = repository;
    }

    public int CreateNewPacienteAsync(PacienteDto paciente)
    {
        return _repository.CreateNewPacienteAsync(paciente);
    }

    public void EliminarPaciente(int Id)
    {
        _repository.EliminarPaciente(Id);
    }

    public IEnumerable<PacienteDto> GetPacientes(string query)
    {
        return _repository.GetPacientes(query);
    }
}

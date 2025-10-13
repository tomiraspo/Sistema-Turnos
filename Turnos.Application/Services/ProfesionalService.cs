using Turnos.Model.UI;
using Turnos.SharedKernel.Interfaces.Repositories;
using Turnos.SharedKernel.Interfaces.Services;

namespace Turnos.Application.Services
{
    public class Profesionalservice : IProfesionalService
    {
        private readonly IProfesionalRepository _repository;

        public Profesionalservice(IProfesionalRepository repository)
        {
            _repository = repository;
        }

        public int CreateNewProfesionalAsync(ProfesionalDto paciente)
        {
            return _repository.CreateNewProfesionalAsync(paciente);
        }

        public IEnumerable<ProfesionalDto> GetProfesionales(string query)
        {
            return _repository.GetProfesionales(query);
        }
        public void EliminarProfesional(int Id)
        {
            _repository.EliminarProfesional(Id);
        }
    }
}

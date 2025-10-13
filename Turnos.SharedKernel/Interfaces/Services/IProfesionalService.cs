using Turnos.Model.UI;

namespace Turnos.SharedKernel.Interfaces.Services
{
    public interface IProfesionalService
    {
        public int CreateNewProfesionalAsync(ProfesionalDto profesional);
        public IEnumerable<ProfesionalDto> GetProfesionales(string query);
        public void EliminarProfesional(int Id);

    }
}

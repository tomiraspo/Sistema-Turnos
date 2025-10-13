using Turnos.Model.UI;

namespace Turnos.SharedKernel.Interfaces.Repositories;

public interface IProfesionalRepository
{
    public int CreateNewProfesionalAsync(ProfesionalDto profesional);
    public IEnumerable<ProfesionalDto> GetProfesionales(string query);
    public void EliminarProfesional(int Id);

}

using Turnos.Model.UI;

namespace Turnos.SharedKernel.Interfaces.Repositories;

public interface IAppointmentRepository
{
    public int CreateNewAppointmentAsync(AppointmentDto appointment);
    public IEnumerable<AppointmentDto> GetAppointmentsAsync();
    public void EditAppointmentAsync(AppointmentDto appointment);
    public void EliminarAppointment(int Id);
}

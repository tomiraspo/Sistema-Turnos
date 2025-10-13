using Microsoft.Extensions.Logging;
using Turnos.Domain.Entities;
using Turnos.Model.UI;
using Turnos.SharedKernel.Interfaces.Repositories;
using Turnos.SharedKernel.Interfaces.Services;

namespace Turnos.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public int CreateNewAppointmentAsync(AppointmentDto appointment)
        {
            return _repository.CreateNewAppointmentAsync(appointment);
        }

        public void EditAppointmentAsync(AppointmentDto appointment)
        {
            _repository.EditAppointmentAsync(appointment);
        }

        public IEnumerable<AppointmentDto> GetAppointmentsAsync()
        {
            return _repository.GetAppointmentsAsync();
        }
        public void EliminarAppointment(int id)
        {
            _repository.EliminarAppointment(id);
        }
    }
}

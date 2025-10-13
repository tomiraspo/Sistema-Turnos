using AutoMapper;
using AutoMapper.QueryableExtensions;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Persistence.Contexts;
using Turnos.Model.UI;
using Microsoft.EntityFrameworkCore;
using Turnos.SharedKernel.Interfaces.Repositories;

namespace Turnos.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;

        public AppointmentRepository(IDbContextFactory<ApplicationDbContext> contextFactory, IConfigurationProvider configurationProvider, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
            _mapper = mapper;
        }

        public int CreateNewAppointmentAsync(AppointmentDto appointment)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var changed = _mapper.Map<AppointmentDto, Appointment>(appointment);

                ctx.Add(changed);
                ctx.SaveChanges();
                return changed.Id;
            }
        }

        public void EditAppointmentAsync(AppointmentDto appointment)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var changed = _mapper.Map<AppointmentDto, Appointment>(appointment);

                Appointment existing = ctx.Appointments.Where(x => x.Id == appointment.Id).FirstOrDefault();

                ctx.Entry(existing).CurrentValues.SetValues(changed);

                ctx.SaveChanges();
            }
        }

        public IEnumerable<AppointmentDto> GetAppointmentsAsync()
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                return ctx.Appointments.ProjectTo<AppointmentDto>(_configurationProvider).ToList();
            }
        }

        public void EliminarAppointment(int Id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var pac = ctx.Appointments.Where(x => x.Id == Id).FirstOrDefault();
                ctx.Appointments.Remove(pac);
                ctx.SaveChanges();
            }
        }
    }
}

using AutoMapper;
using Turnos.Domain.Entities;
using Turnos.Model.UI;

namespace Turnos.SharedKernel.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile() {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Paciente, PacienteDto>().ReverseMap();
            CreateMap<Profesional, ProfesionalDto>().ReverseMap();
        }
    }
}

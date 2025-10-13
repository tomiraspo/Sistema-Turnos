using AutoMapper;
using AutoMapper.QueryableExtensions;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Persistence.Contexts;
using Turnos.Model.UI;
using Microsoft.EntityFrameworkCore;
using Turnos.SharedKernel.Interfaces.Repositories;
using System.Collections.Generic;

namespace Turnos.Infrastructure.Persistence.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;

        public PacienteRepository(IDbContextFactory<ApplicationDbContext> contextFactory, IConfigurationProvider configurationProvider, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
            _mapper = mapper;
        }

        public int CreateNewPacienteAsync(PacienteDto paciente)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var changed = _mapper.Map<PacienteDto, Paciente>(paciente);

                ctx.Add(changed);
                ctx.SaveChanges();
                return changed.Id;
            }
        }

        public void EliminarPaciente(int Id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var pac = ctx.Pacientes.Where(x => x.Id == Id).FirstOrDefault();
                ctx.Pacientes.Remove(pac);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<PacienteDto> GetPacientes(string query)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                return ctx.Pacientes
                    .Where(x => x.Nombre.Contains(query) || x.Apellido.Contains(query)).ProjectTo<PacienteDto>(_configurationProvider).ToList();
            }
        }
    }
}

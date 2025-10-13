using AutoMapper;
using AutoMapper.QueryableExtensions;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Persistence.Contexts;
using Turnos.Model.UI;
using Microsoft.EntityFrameworkCore;
using Turnos.SharedKernel.Interfaces.Repositories;

namespace Turnos.Infrastructure.Persistence.Repositories
{
    public class ProfesionalRepository : IProfesionalRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;

        public ProfesionalRepository(IDbContextFactory<ApplicationDbContext> contextFactory, IConfigurationProvider configurationProvider, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _configurationProvider = configurationProvider;
            _mapper = mapper;
        }

        public int CreateNewProfesionalAsync(ProfesionalDto profesional)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var changed = _mapper.Map<ProfesionalDto, Profesional>(profesional);

                ctx.Add(changed);
                ctx.SaveChanges();
                return changed.Id;
            }
        }

        public IEnumerable<ProfesionalDto> GetProfesionales(string query)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                return ctx.Profesionales
                    .Where(x => x.Nombre.Contains(query) || x.Apellido.Contains(query)).ProjectTo<ProfesionalDto>(_configurationProvider).ToList();
            }
        }

        public void EliminarProfesional(int Id)
        {
            using (var ctx = _contextFactory.CreateDbContext())
            {
                var pro = ctx.Profesionales.Where(x => x.Id == Id).FirstOrDefault();
                ctx.Profesionales.Remove(pro);
                ctx.SaveChanges();
            }
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Turnos.SharedKernel
{
    public static class ServiceExtensions
    {
        public static void AddDomainProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
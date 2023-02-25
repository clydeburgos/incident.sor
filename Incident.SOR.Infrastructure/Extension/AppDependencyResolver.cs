using DapperExtensions;
using Incident.SOR.Application.Persistence;
using Incident.SOR.Core.Persistence;
using Incident.SOR.Domain.Configs;
using Incident.SOR.Domain.DTO;
using Incident.SOR.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppDependencyResolver
    {
        public static void ConfigureIncidentSORServices(this IServiceCollection services, IConfiguration configuration) {
            ConnectionStrings connectionString = new ConnectionStrings();
            configuration.GetSection("ConnectionStrings").Bind(connectionString);
            services.AddSingleton(connectionString);

            services.AddScoped<IDataAccessBase, DataAccessBase>();
            services.AddScoped<IRepository<IncidentDto>, IncidentService>();
        }
    }
}

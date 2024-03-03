using Consultorio.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consultorio.Infra.IoC
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                      IConfiguration Configuration)
        {
            services.AddDbContext<ConsultorioDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("DataBase"),
                    b => b.MigrationsAssembly(typeof(ConsultorioDbContext).Assembly.FullName)));

            return services;

        }
    }
}

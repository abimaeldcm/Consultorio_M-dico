using Consultorio.Application.Interface;
using Consultorio.Application.Mapping;
using Consultorio.Application.Service;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data;
using Consultorio.Infra.Data.Interfaces;
using Consultorio.Infra.Data.Repository;
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
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddDbContext<ConsultorioDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("DataBase"),
                    b => b.MigrationsAssembly(typeof(ConsultorioDbContext).Assembly.FullName)));

            //Atendimento
            services.AddScoped<ICRUDService<AtendimentoOutputDTO,AtendimentoInputDTO>, AtendimentoService>();
            services.AddScoped<ICRUDRepository<Atendimento>, AtendimentoRepository>();
            
            //Espacialidade
            services.AddScoped<ICRUDService<EspecialidadeOutputDTO,EspecialidadeInputDTO>, EspecialidadeService>();
            services.AddScoped<ICRUDRepository<Especialidade>, EspecialidadeRepository>();

            //Médico
            services.AddScoped<ICRUDService<MedicoOutputDTO,MedicoInputDTO>, MedicoService>();
            services.AddScoped<ICRUDRepository<Medico>, MedicoRepository>();

            //Paciente
            services.AddScoped<ICRUDService<PacienteOutputDTO,PacienteInputDTO>, PacienteService>();
            services.AddScoped<ICRUDRepository<Paciente>, PacienteRepository>();

            //Servico
            services.AddScoped<ICRUDService<ServicoOutputDTO,ServicoInputDTO>, ServicoService>();
            services.AddScoped<ICRUDRepository<Servico>, ServicoRepository>();

            return services;

        }
    }
}

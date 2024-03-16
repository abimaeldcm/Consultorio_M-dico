using Consultorio.Application.Calendario;
using Consultorio.Application.Email;
using Consultorio.Application.Interface;
using Consultorio.Application.Mapping;
using Consultorio.Application.Service;
using Consultorio.Application.Validations;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Consultorio.Infra.Data;
using Consultorio.Infra.Data.Interfaces;
using Consultorio.Infra.Data.Repository;
using FluentValidation.AspNetCore;
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
            services.AddScoped<ICRUDService<ConsultOutputDTO,ConsultInputDTO>, ConsultService>();
            services.AddScoped<ICRUDRepository<Consult>, ConsultRepository>();
            
            //Espacialidade
            services.AddScoped<ICRUDService<SpecialityOutputDTO,SpecialityInputDTO>, SpecialityService>();
            services.AddScoped<ICRUDRepository<Specialty>, EspecialidadeRepository>();

            //Médico
            services.AddScoped<ICRUDService<DoctorOutputDTO,DoctorInputDTO>, DoctorService>();
            services.AddScoped<ICRUDRepository<Doctor>, DoctorRepository>();

            //Paciente
            services.AddScoped<ICRUDService<PatientOutputDTO,PatientInputDTO>, PatientService>();
            services.AddScoped<ICRUDRepository<Patient>, PatientRepository>();

            //Servico
            services.AddScoped<ICRUDService<ServiceOutputDTO,ServiceInputDTO>, ServiceService>();
            services.AddScoped<ICRUDRepository<ServiceEntity>, ServiceRepository>();

            services.AddScoped<ICRUDRepository<ServiceEntity>, ServiceRepository>();

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SpecialityValidation>());

            services.AddScoped<ISeedEmail, SeedEmail>();


            return services;

        }
    }
}

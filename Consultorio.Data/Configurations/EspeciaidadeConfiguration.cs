using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Infra.Data.Configurations
{
    public class EspeciaidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasData(
                    new Especialidade { Id = 1, EspecialidadeMedica = "Clínico Geral" },
                    new Especialidade { Id = 2, EspecialidadeMedica = "Cardiologia" },
                    new Especialidade { Id = 3, EspecialidadeMedica = "Pediatria" },
                    new Especialidade { Id = 4, EspecialidadeMedica = "Ortopedia" },
                    new Especialidade { Id = 5, EspecialidadeMedica = "Dermatologia" },
                    new Especialidade { Id = 6, EspecialidadeMedica = "Oftalmologia" },
                    new Especialidade { Id = 7, EspecialidadeMedica = "Psiquiatria" },
                    new Especialidade { Id = 8, EspecialidadeMedica = "Ginecologia" },
                    new Especialidade { Id = 9, EspecialidadeMedica = "Urologia" },
                    new Especialidade { Id = 10, EspecialidadeMedica = "Neurologia" }
                );

        }
    }
}

using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Infra.Data.Configurations
{
    public class EspeciaidadeConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasData(
                    new Specialty { Id = 1, EspecialidadeMedica = "Clínico Geral" },
                    new Specialty { Id = 2, EspecialidadeMedica = "Cardiologia" },
                    new Specialty { Id = 3, EspecialidadeMedica = "Pediatria" },
                    new Specialty { Id = 4, EspecialidadeMedica = "Ortopedia" },
                    new Specialty { Id = 5, EspecialidadeMedica = "Dermatologia" },
                    new Specialty { Id = 6, EspecialidadeMedica = "Oftalmologia" },
                    new Specialty { Id = 7, EspecialidadeMedica = "Psiquiatria" },
                    new Specialty { Id = 8, EspecialidadeMedica = "Ginecologia" },
                    new Specialty { Id = 9, EspecialidadeMedica = "Urologia" },
                    new Specialty { Id = 10, EspecialidadeMedica = "Neurologia" }
                );

        }
    }
}

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
                    new Specialty { Id = 1, MedicalSpecialty = "Clínico Geral" },
                    new Specialty { Id = 2, MedicalSpecialty = "Cardiologia" },
                    new Specialty { Id = 3, MedicalSpecialty = "Pediatria" },
                    new Specialty { Id = 4, MedicalSpecialty = "Ortopedia" },
                    new Specialty { Id = 5, MedicalSpecialty = "Dermatologia" },
                    new Specialty { Id = 6, MedicalSpecialty = "Oftalmologia" },
                    new Specialty { Id = 7, MedicalSpecialty = "Psiquiatria" },
                    new Specialty { Id = 8, MedicalSpecialty = "Ginecologia" },
                    new Specialty { Id = 9, MedicalSpecialty = "Urologia" },
                    new Specialty { Id = 10, MedicalSpecialty = "Neurologia" }
                );

        }
    }
}

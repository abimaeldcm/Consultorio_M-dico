using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Infra.Data.Configurations
{
    public class EspeciaidadeConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasData(
                    new Speciality { Id = 1, MedicalSpeciality = "Clínico Geral" },
                    new Speciality { Id = 2, MedicalSpeciality = "Cardiologia" },
                    new Speciality { Id = 3, MedicalSpeciality = "Pediatria" },
                    new Speciality { Id = 4, MedicalSpeciality = "Ortopedia" },
                    new Speciality { Id = 5, MedicalSpeciality = "Dermatologia" },
                    new Speciality { Id = 6, MedicalSpeciality = "Oftalmologia" },
                    new Speciality { Id = 7, MedicalSpeciality = "Psiquiatria" },
                    new Speciality { Id = 8, MedicalSpeciality = "Ginecologia" },
                    new Speciality { Id = 9, MedicalSpeciality = "Urologia" },
                    new Speciality { Id = 10, MedicalSpeciality = "Neurologia" }
                );

        }
    }
}

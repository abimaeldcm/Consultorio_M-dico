using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Consultorio.Domain.Entity.Enum;

namespace Consultorio.Infra.Data.Configurations
{
    public class PatientConfigurations : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);

            builder.HasData(
                    new Patient { Id = 1, Name = "Maria", LastName = "da Silva", BirthDate = new DateTime(1990, 07, 15), PhoneNumber = "869988776655", Email = "maria.silva@email.com", CPF = "12345678901", BloodType = ETBloodType.ABPositive, Address = "Rua das Flores, Nº 10", Height = 1.36, Weight = 70 },
                    new Patient { Id = 2, Name = "José", LastName = "Santos", BirthDate = new DateTime(1985, 05, 20), PhoneNumber = "869977665544", Email = "jose.santos@email.com", CPF = "23456789012", BloodType = ETBloodType.BNegative, Address = "Av. Central, Nº 50", Height = 1.80, Weight = 85 },
                    new Patient { Id = 3, Name = "Ana", LastName = "Souza", BirthDate = new DateTime(1993, 09, 10), PhoneNumber = "869966554433", Email = "ana.souza@email.com", CPF = "34567890123", BloodType = ETBloodType.ABNegative, Address = "Rua dos Pássaros, Nº 25", Height = 1.65, Weight = 60 },
                    new Patient { Id = 4, Name = "Carlos", LastName = "Oliveira", BirthDate = new DateTime(1980, 03, 05), PhoneNumber = "869955443322", Email = "carlos.oliveira@email.com", CPF = "45678901234", BloodType = ETBloodType.OPositive, Address = "Av. Brasil, Nº 100", Height = 1.70, Weight = 75 },
                    new Patient { Id = 5, Name = "Mariana", LastName = "Costa", BirthDate = new DateTime(1975, 12, 30), PhoneNumber = "869944332211", Email = "mariana.costa@email.com", CPF = "56789012345", BloodType = ETBloodType.ABPositive, Address = "Rua Principal, Nº 300", Height = 1.60, Weight = 65 },
                    new Patient { Id = 6, Name = "Rafael", LastName = "Oliveira", BirthDate = new DateTime(1992, 08, 18), PhoneNumber = "869933221100", Email = "rafael.oliveira@email.com", CPF = "67890123456", BloodType = ETBloodType.ABNegative, Address = "Av. das Árvores, Nº 15", Height = 1.85, Weight = 80 },
                    new Patient { Id = 7, Name = "Juliana", LastName = "Lima", BirthDate = new DateTime(1987, 06, 25), PhoneNumber = "869922110011", Email = "juliana.lima@email.com", CPF = "78901234567", BloodType = ETBloodType.BPositive, Address = "Rua do Sol, Nº 200", Height = 1.75, Weight = 70 },
                    new Patient { Id = 8, Name = "Fernando", LastName = "Santos", BirthDate = new DateTime(1996, 04, 12), PhoneNumber = "869911001122", Email = "fernando.santos@email.com", CPF = "89012345678", BloodType = ETBloodType.ABNegative, Address = "Av. das Estrelas, Nº 75", Height = 1.80, Weight = 85 },
                    new Patient { Id = 9, Name = "Abimael", LastName = "Mendes", BirthDate = new DateTime(1997, 04, 25), PhoneNumber = "86995287928", Email = "abimaelmends@hotmail.com", CPF = "89012345678", BloodType = ETBloodType.ABNegative, Address = "Av. das Estrelas, Nº 75", Height = 1.80, Weight = 85 }
                    );
        }
    }
}

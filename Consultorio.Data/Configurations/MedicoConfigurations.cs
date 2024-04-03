using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Consultorio.Domain.Entity.Enum;

namespace Consultorio.Infra.Data.Configurations
{
    internal class MedicoConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
               .HasOne(m => m.Speciality)
               .WithMany()
               .HasForeignKey(m => m.IdSpeciality);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
            builder.Property(x => x.RegisterCRM).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Doctor { Id = 1, Name = "Antônio", LastName = "Pereira Caudas", BirthDate = new DateTime(1997, 04, 25), PhoneNumber = "86995287928", Email = "AntonioCaudas@email.com", CPF = "06445663225", BloodType = ETBloodType.ABPositive, Address = "Rua dos Bobos, Nº 0", IdSpeciality = 1, RegisterCRM = "12345/PI" },
                new Doctor { Id = 2, Name = "João", LastName = "da Silva", BirthDate = new DateTime(1985, 10, 15), PhoneNumber = "86995554433", Email = "joao.silva@email.com", CPF = "09876543210", BloodType = ETBloodType.ONegative, Address = "Av. Brasil, Nº 100", IdSpeciality = 2, RegisterCRM = "54321/PI" },
                new Doctor { Id = 3, Name = "Maria", LastName = "Oliveira", BirthDate = new DateTime(1976, 07, 22), PhoneNumber = "869944332211", Email = "maria.oliveira@email.com", CPF = "11223344556", BloodType = ETBloodType.ABNegative, Address = "Rua das Flores, Nº 50", IdSpeciality = 2, RegisterCRM = "67890/PI" },
                new Doctor { Id = 4, Name = "Carlos", LastName = "Souza", BirthDate = new DateTime(1990, 03, 30), PhoneNumber = "869966998877", Email = "carlos.souza@email.com", CPF = "55443322111", BloodType = ETBloodType.OPositive, Address = "Av. Principal, Nº 300", IdSpeciality = 4, RegisterCRM = "13579/PI" },
                new Doctor { Id = 5, Name = "Ana", LastName = "Santos", BirthDate = new DateTime(1983, 11, 18), PhoneNumber = "869977776655", Email = "ana.santos@email.com", CPF = "33445566778", BloodType = ETBloodType.ABNegative, Address = "Rua da Paz, Nº 15", IdSpeciality = 5, RegisterCRM = "24680/PI" },
                new Doctor { Id = 6, Name = "Pedro", LastName = "Moraes", BirthDate = new DateTime(1988, 05, 08), PhoneNumber = "869988887766", Email = "pedro.moraes@email.com", CPF = "99887766554", BloodType = ETBloodType.BPositive, Address = "Av. Central, Nº 200", IdSpeciality = 6,RegisterCRM = "97531/PI" },
                new Doctor { Id = 7, Name = "Fernanda", LastName = "Costa", BirthDate = new DateTime(1980, 09, 12), PhoneNumber = "869933377755", Email = "fernanda.costa@email.com", CPF = "22113344556", BloodType = ETBloodType.ABNegative, Address = "Rua das Árvores, Nº 30", IdSpeciality = 7, RegisterCRM = "86420/PI" },
                new Doctor { Id = 8, Name = "Rafaela", LastName = "Lima", BirthDate = new DateTime(1995, 02, 28), PhoneNumber = "869922223344", Email = "rafaela.lima@email.com", CPF = "77889900123", BloodType = ETBloodType.ABPositive, Address = "Av. das Estrelas, Nº 75", IdSpeciality = 8, RegisterCRM = "54321/PI" }
                );
        }
    }
}

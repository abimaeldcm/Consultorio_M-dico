using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Consultorio.Domain.Entity.Enum;

namespace Consultorio.Infra.Data.Configurations
{
    internal class MedicoConfigurations : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder
               .HasOne(m => m.Especialidade)
               .WithMany()
               .HasForeignKey(m => m.IdEspecialidade);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(200);
            builder.Property(x => x.RegistroCRM).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Medico { Id = 1, Nome = "Antônio Pereira Caudas", Sobrenome = "Pereira Caudas", DataNascimento = new DateTime(1997, 04, 25), Telefone = "86995287928", Email = "AntonioCaudas@email.com", CPF = "06445663225", TipoSanguineo = ETipoSanguineo.APositivo, Endereco = "Rua dos Bobos, Nº 0", IdEspecialidade = 1, RegistroCRM = "12345/PI" },
                new Medico { Id = 2, Nome = "João da Silva", Sobrenome = "da Silva", DataNascimento = new DateTime(1985, 10, 15), Telefone = "86995554433", Email = "joao.silva@email.com", CPF = "09876543210", TipoSanguineo = ETipoSanguineo.ONegativo, Endereco = "Av. Brasil, Nº 100", IdEspecialidade = 2, RegistroCRM = "54321/PI" },
                new Medico { Id = 3, Nome = "Maria Oliveira", Sobrenome = "Oliveira", DataNascimento = new DateTime(1976, 07, 22), Telefone = "869944332211", Email = "maria.oliveira@email.com", CPF = "11223344556", TipoSanguineo = ETipoSanguineo.ABNegativo, Endereco = "Rua das Flores, Nº 50", IdEspecialidade = 2, RegistroCRM = "67890/PI" },
                new Medico { Id = 4, Nome = "Carlos Souza", Sobrenome = "Souza", DataNascimento = new DateTime(1990, 03, 30), Telefone = "869966998877", Email = "carlos.souza@email.com", CPF = "55443322111", TipoSanguineo = ETipoSanguineo.OPositivo, Endereco = "Av. Principal, Nº 300", IdEspecialidade = 4, RegistroCRM = "13579/PI" },
                new Medico { Id = 5, Nome = "Ana Santos", Sobrenome = "Santos", DataNascimento = new DateTime(1983, 11, 18), Telefone = "869977776655", Email = "ana.santos@email.com", CPF = "33445566778", TipoSanguineo = ETipoSanguineo.ABNegativo, Endereco = "Rua da Paz, Nº 15", IdEspecialidade = 5, RegistroCRM = "24680/PI" },
                new Medico { Id = 6, Nome = "Pedro Moraes", Sobrenome = "Moraes", DataNascimento = new DateTime(1988, 05, 08), Telefone = "869988887766", Email = "pedro.moraes@email.com", CPF = "99887766554", TipoSanguineo = ETipoSanguineo.BPositivo, Endereco = "Av. Central, Nº 200", IdEspecialidade = 6,RegistroCRM = "97531/PI" },
                new Medico { Id = 7, Nome = "Fernanda Costa", Sobrenome = "Costa", DataNascimento = new DateTime(1980, 09, 12), Telefone = "869933377755", Email = "fernanda.costa@email.com", CPF = "22113344556", TipoSanguineo = ETipoSanguineo.ABNegativo, Endereco = "Rua das Árvores, Nº 30", IdEspecialidade = 7, RegistroCRM = "86420/PI" },
                new Medico { Id = 8, Nome = "Rafaela Lima", Sobrenome = "Lima", DataNascimento = new DateTime(1995, 02, 28), Telefone = "869922223344", Email = "rafaela.lima@email.com", CPF = "77889900123", TipoSanguineo = ETipoSanguineo.ABPositivo, Endereco = "Av. das Estrelas, Nº 75", IdEspecialidade = 8, RegistroCRM = "54321/PI" }
                );
        }
    }
}

using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Consultorio.Domain.Entity.Enum;

namespace Consultorio.Infra.Data.Configurations
{
    public class PacienteConfigurations : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(200);

            builder.HasData(
                    new Paciente { Id = 1, Nome = "Maria da Silva", Sobrenome = "da Silva", DataNascimento = new DateTime(1990, 07, 15), Telefone = "869988776655", Email = "maria.silva@email.com", CPF = "12345678901", TipoSanguineo = ETipoSanguineo.APositivo, Endereco = "Rua das Flores, Nº 10", Altura = 1.36, Peso = 70 },
                    new Paciente { Id = 2, Nome = "José Santos", Sobrenome = "Santos", DataNascimento = new DateTime(1985, 05, 20), Telefone = "869977665544", Email = "jose.santos@email.com", CPF = "23456789012", TipoSanguineo = ETipoSanguineo.BNegativo, Endereco = "Av. Central, Nº 50", Altura = 1.80, Peso = 85 },
                    new Paciente { Id = 3, Nome = "Ana Souza", Sobrenome = "Souza", DataNascimento = new DateTime(1993, 09, 10), Telefone = "869966554433", Email = "ana.souza@email.com", CPF = "34567890123", TipoSanguineo = ETipoSanguineo.ABNegativo, Endereco = "Rua dos Pássaros, Nº 25", Altura = 1.65, Peso = 60 },
                    new Paciente { Id = 4, Nome = "Carlos Oliveira", Sobrenome = "Oliveira", DataNascimento = new DateTime(1980, 03, 05), Telefone = "869955443322", Email = "carlos.oliveira@email.com", CPF = "45678901234", TipoSanguineo = ETipoSanguineo.OPositivo, Endereco = "Av. Brasil, Nº 100", Altura = 1.70, Peso = 75 },
                    new Paciente { Id = 5, Nome = "Mariana Costa", Sobrenome = "Costa", DataNascimento = new DateTime(1975, 12, 30), Telefone = "869944332211", Email = "mariana.costa@email.com", CPF = "56789012345", TipoSanguineo = ETipoSanguineo.APositivo, Endereco = "Rua Principal, Nº 300", Altura = 1.60, Peso = 65 },
                    new Paciente { Id = 6, Nome = "Rafael Oliveira", Sobrenome = "Oliveira", DataNascimento = new DateTime(1992, 08, 18), Telefone = "869933221100", Email = "rafael.oliveira@email.com", CPF = "67890123456", TipoSanguineo = ETipoSanguineo.ABNegativo, Endereco = "Av. das Árvores, Nº 15", Altura = 1.85, Peso = 80 },
                    new Paciente { Id = 7, Nome = "Juliana Lima", Sobrenome = "Lima", DataNascimento = new DateTime(1987, 06, 25), Telefone = "869922110011", Email = "juliana.lima@email.com", CPF = "78901234567", TipoSanguineo = ETipoSanguineo.BPositivo, Endereco = "Rua do Sol, Nº 200", Altura = 1.75, Peso = 70 },
                    new Paciente { Id = 8, Nome = "Fernando Santos", Sobrenome = "Santos", DataNascimento = new DateTime(1996, 04, 12), Telefone = "869911001122", Email = "fernando.santos@email.com", CPF = "89012345678", TipoSanguineo = ETipoSanguineo.ABNegativo, Endereco = "Av. das Estrelas, Nº 75", Altura = 1.80, Peso = 85 }
                    );
        }
    }
}

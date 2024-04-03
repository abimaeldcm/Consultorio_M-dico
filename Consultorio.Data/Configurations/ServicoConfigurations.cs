using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Configurations
{
    public class ServicoConfigurations : IEntityTypeConfiguration<ServiceEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Value).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Value).IsRequired();
            builder.HasData(
                 new ServiceEntity { Id = 1, Name = "Clínico Geral", Description = "Atendimento médico geral para pacientes de todas as idades.", Duration = 60, Value = 150 },
                 new ServiceEntity { Id = 2, Name = "Cardiologia", Description = "Especialidade médica que se ocupa do diagnóstico e tratamento das doenças que acometem o coração.", Duration = 60, Value = 200 },
                 new ServiceEntity { Id = 3, Name = "Pediatria", Description = "Especialidade médica dedicada à assistência à criança e ao adolescente, nos seus diversos aspectos, sejam eles preventivos ou curativos.", Duration = 45, Value = 120 },
                 new ServiceEntity { Id = 4, Name = "Ortopedia", Description = "Especialidade médica que cuida das doenças e deformidades dos ossos, músculos, ligamentos e articulações.", Duration = 45, Value = 180 },
                 new ServiceEntity { Id = 5, Name = "Dermatologia", Description = "Especialidade médica que cuida da saúde da pele, cabelos e unhas.", Duration = 30, Value = 100 },
                 new ServiceEntity { Id = 6, Name = "Oftalmologia", Description = "Especialidade médica que trata das doenças relacionadas com os olhos e com a visão.", Duration = 30, Value = 150 },
                 new ServiceEntity { Id = 7, Name = "Psiquiatria", Description = "Especialidade médica que lida com a prevenção, atendimento, diagnóstico, tratamento e reabilitação das diferentes formas de sofrimentos mentais, sejam elas de cunho orgânico ou funcional.", Duration = 60, Value = 250 },
                 new ServiceEntity { Id = 8, Name = "Ginecologia", Description = "Especialidade médica que trata da saúde da mulher, especialmente do sistema reprodutor feminino.", Duration = 45, Value = 180 },
                 new ServiceEntity { Id = 9, Name = "Urologia", Description = "Especialidade médica que trata do trato urinário de homens e mulheres e do sistema reprodutor dos homens.", Duration = 45, Value = 200 },
                 new ServiceEntity { Id = 10, Name = "Neurologia", Description = "Especialidade médica que trata dos distúrbios estruturais do sistema nervoso.", Duration = 60, Value = 220 }
             );

        }
    }
}
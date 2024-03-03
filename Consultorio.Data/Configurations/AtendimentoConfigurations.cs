using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Infra.Data.Configurations
{
    internal class AtendimentoConfigurations : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.IdPaciente).IsRequired();

            builder
                .HasOne(a => a.Servico)
                .WithMany()
                .HasForeignKey(a => a.IdServico).IsRequired();

            builder
                .HasOne(a => a.Medico)
                .WithMany()
                .HasForeignKey(a => a.IdMedico).IsRequired();
        }
    }
}

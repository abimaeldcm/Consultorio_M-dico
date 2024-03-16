using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Infra.Data.Configurations
{
    internal class AtendimentoConfigurations : IEntityTypeConfiguration<Consult>
    {
        public void Configure(EntityTypeBuilder<Consult> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.IdPatient).IsRequired();

            builder
                .HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.IdService).IsRequired();

            builder
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.IdDoctor).IsRequired();
        }
    }
}

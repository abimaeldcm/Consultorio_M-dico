using Consultorio.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Infra.Data.Configurations
{
    public class ServicoConfigurations : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Valor).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Valor).IsRequired();
        }
    }
}
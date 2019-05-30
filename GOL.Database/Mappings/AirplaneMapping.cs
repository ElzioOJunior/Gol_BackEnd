using GOL.Domain.Entities.Airplane;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GOL.Database.Mappings
{
    public class AirplaneMapping : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.CodigoAviao)
                .HasColumnName("CodigoAviao")
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(o => o.Modelo)
                .HasColumnName("Modelo")
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(o => o.QtdPassageiros)
                .HasColumnName("QtdPassageiros")
                .HasColumnType("int")
                .IsRequired();

        }
    }
}

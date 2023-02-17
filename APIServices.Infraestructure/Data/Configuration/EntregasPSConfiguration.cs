using APIServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIServices.Infraestructure.Data.Configuration
{
    public class EntregasPSConfiguration : IEntityTypeConfiguration<EntregasPs>
    {
        public void Configure(EntityTypeBuilder<EntregasPs> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("EntregasPS");

            builder.HasIndex(e => e.Fkfolio)
                .HasName("UQ__Entregas__B6EBE3AA1000E73C")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("IDEntregas");

            builder.Property(e => e.EstadoEntrega)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FechaEntrega).HasColumnType("datetime");

            builder.Property(e => e.Fkfolio)
                .IsRequired()
                .HasColumnName("FKFolio")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Foto).HasMaxLength(250);

            builder.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Pdfurl)
                .HasColumnName("PDFUrl")
                .HasMaxLength(250);

            builder.HasOne(d => d.FkfolioNavigation)
                .WithOne(p => p.EntregasPs)
                .HasPrincipalKey<OrdenCompra>(p => p.Folio)
                .HasForeignKey<EntregasPs>(d => d.Fkfolio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EntregasPS_OrdenCompra");

        }
    }
}

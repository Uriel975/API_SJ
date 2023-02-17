using APIServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIServices.Infraestructure.Data.Configuration
{
    public class OrdenCompraConfiguration : IEntityTypeConfiguration<OrdenCompra>
    {
        public void Configure(EntityTypeBuilder<OrdenCompra> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
            .HasColumnName("IdOrdenCompra");

            builder.HasIndex(e => e.Folio)
                .HasName("UQ__OrdenCom__BAB84EF783B5B7F6")
                .IsUnique();

            builder.Property(e => e.FechaOrden).HasColumnType("datetime");

            builder.Property(e => e.Fkempresa).HasColumnName("FKEmpresa");

            builder.Property(e => e.Folio)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.FkempresaNavigation)
                .WithMany(p => p.OrdenCompra)
                .HasForeignKey(d => d.Fkempresa)
                .HasConstraintName("FK_OrdenCompra_ClienteEmpresa");

            builder.Property(e => e.PDFRoute)
                .IsRequired(false)
                .HasColumnName("PDFRoute")
                .HasMaxLength(250);
        }
    }
}

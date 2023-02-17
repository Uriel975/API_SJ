using APIServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIServices.Infraestructure.Data.Configuration
{
    public class ClienteEmpresaConfiguration : IEntityTypeConfiguration<ClienteEmpresa>
    {
        public void Configure(EntityTypeBuilder<ClienteEmpresa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("IDEmpresa");

            builder.Property(e => e.Contacto)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.NombreFiscal)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}

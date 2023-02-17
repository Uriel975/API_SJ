using APIServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIServices.Infraestructure.Data.Configuration
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdUsuario");

            builder.Property(e => e.ApellidoM)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ApellidoP)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Contra)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Rol)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}

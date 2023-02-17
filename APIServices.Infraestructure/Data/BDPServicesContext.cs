using APIServices.Domain.Entities;
using APIServices.Infraestructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APIServices.Infraestructure.Data
{
    public partial class BDPServicesContext : DbContext
    {
        public BDPServicesContext()
        {
        }

        public BDPServicesContext(DbContextOptions<BDPServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteEmpresa> ClienteEmpresa { get; set; }
        public virtual DbSet<EntregasPs> EntregasPs { get; set; }
        public virtual DbSet<OrdenCompra> OrdenCompra { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Se dividieron en clases en la carpeta "Configuration"

            modelBuilder.ApplyConfiguration(new UsuariosConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteEmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new EntregasPSConfiguration());
            modelBuilder.ApplyConfiguration(new OrdenCompraConfiguration());


        }

    }
}

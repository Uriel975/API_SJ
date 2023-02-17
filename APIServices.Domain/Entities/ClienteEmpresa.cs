using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APIServices.Domain.Entities
{
    public partial class ClienteEmpresa : BaseEntity
    {
        public ClienteEmpresa()
        {
            OrdenCompra = new HashSet<OrdenCompra>();
        }

        //public int Idempresa { get; set; }
        public string NombreFiscal { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
    }
}

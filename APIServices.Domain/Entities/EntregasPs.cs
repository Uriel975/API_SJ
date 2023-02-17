using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APIServices.Domain.Entities
{
    public partial class EntregasPs : BaseEntity
    {
        //public int Identregas { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string Observaciones { get; set; }
        public string Foto { get; set; }
        public string EstadoEntrega { get; set; }
        public byte[] Pdfurl { get; set; }
        public string Fkfolio { get; set; }

        public virtual OrdenCompra FkfolioNavigation { get; set; }
    }
}

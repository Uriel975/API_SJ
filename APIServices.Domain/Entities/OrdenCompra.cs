using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APIServices.Domain.Entities
{
    public partial class OrdenCompra : BaseEntity
    {
        //public int IdOrdenCompra { get; set; }
        public string Folio { get; set; }
        public DateTime? FechaOrden { get; set; }
        public string Serie { get; set; }
        public int? Fkempresa { get; set; }
        public string PDFRoute { get; set; }

        public virtual ClienteEmpresa FkempresaNavigation { get; set; }
        public virtual EntregasPs EntregasPs { get; set; }
    }
}

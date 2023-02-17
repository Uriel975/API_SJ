using System;
using System.Collections.Generic;
using System.Text;

namespace APIServices.Domain.DTOs
{
    public class OrdenCompraDto
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public DateTime? FechaOrden { get; set; }
        public string Serie { get; set; }
        public int? Fkempresa { get; set; }
        public string PDFRoute { get; set; }
    }
}

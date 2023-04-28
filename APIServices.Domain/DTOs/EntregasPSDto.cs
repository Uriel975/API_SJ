using System;
using System.Collections.Generic;
using System.Text;

namespace APIServices.Domain.DTOs
{
    public class EntregasPSDto
    {
        public int Id { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string Observaciones { get; set; }
        public string Foto { get; set; }
        public string EstadoEntrega { get; set; }
        public string Pdfurl { get; set; }
        public string Fkfolio { get; set; }
    }
}

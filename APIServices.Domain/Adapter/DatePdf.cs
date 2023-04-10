using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIServices.Domain.Adapter
{
    public class DatePdf
    {
        public IFormFile Firma { get; set; }
        public string RoutePdf { get; set; }
        public string Folio { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string Observaciones { get; set; }
        public string EstadoEntrega { get; set; }
    }
}

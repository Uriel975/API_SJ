using System;
using System.Collections.Generic;
using System.Text;

namespace APIServices.Domain.DTOs
{
    public class ClienteEmpresaDto
    {
        public int Id { get; set; }
        public string NombreFiscal { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace APIServices.Domain.DTOs

{
    public class UsuariosDto
    {
        // Son Objetos planos ya que no debe tener nada de logica
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Correo { get; set; }
        public string Contra { get; set; }
        public string Rol { get; set; }

    }
}

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable
namespace APIServices.Domain.Entities
{
    public partial class Usuarios : BaseEntity
    {
        //public int IdUsuario { get; set; }

        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Correo { get; set; }
        public string Contra { get; set; }
        public string Rol { get; set; }


    }
}

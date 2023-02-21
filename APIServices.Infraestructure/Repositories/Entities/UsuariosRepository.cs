using APIServices.Domain.Entities;
using APIServices.Domain.Exceptions;
using APIServices.Domain.Services.Entities;
using APIServices.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace APIServices.Infraestructure.Repositories.Entities
{
    public class UsuariosRepository : BaseRepository<Usuarios>, IUsuariosRepository
    {
        public UsuariosRepository(BDPServicesContext context) : base(context) {}

        public async Task<Usuarios> Login(Usuarios usuarios)
        {
            var user = await _entities.Where(x => x.Usuario == usuarios.Usuario).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new BusinessException("El usuario no existe.");
            }

            if (user.Contra != usuarios.Contra)
            {
                throw new BusinessException("La contraseña es incorrecta.");
            }

            if (user.Rol == "Inactivo")
            {
                throw new BusinessException("El usuario no está activo.");
            }

            return user;
        }
    }
}

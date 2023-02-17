using APIServices.Domain.Entities;
using APIServices.Domain.Services.Entities;
using APIServices.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace APIServices.Infraestructure.Repositories.Entities
{
    public class UsuariosRepository : BaseRepository<Usuarios>, IUsuariosRepository
    {
        public UsuariosRepository(BDPServicesContext context) : base(context) {}

        public async Task<Usuarios> Login(Usuarios usuarios)
        {
            var user = await _entities.FirstOrDefaultAsync(x =>
                x.Usuario == usuarios.Usuario &&
                x.Contra == usuarios.Contra);

            return user;
        }
    }
}

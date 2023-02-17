using APIServices.Domain.Entities;
using APIServices.Domain.Interfaces;
using System.Threading.Tasks;

namespace APIServices.Domain.Services.Entities
{
    public interface IUsuariosRepository: IRepository<Usuarios>
    {

        Task<Usuarios> Login(Usuarios usuarios);

    }
}
  
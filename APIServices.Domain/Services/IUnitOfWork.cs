using APIServices.Domain.Entities;
using APIServices.Domain.Interfaces;
using APIServices.Domain.Services.Entities;
using System;
using System.Threading.Tasks;

namespace APIServices.Domain.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuariosRepository UsersRepository { get; }
        IRepository<ClienteEmpresa> ClienteEmpRepository { get; }
        IRepository<EntregasPs> EntregasPSRespository { get; }
        IRepository<OrdenCompra> OrdenCompraRepository { get; }




        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

using APIServices.Domain.Entities;
using APIServices.Domain.Interfaces;
using APIServices.Domain.Services;
using APIServices.Domain.Services.Entities;
using APIServices.Infraestructure.Data;
using APIServices.Infraestructure.Repositories.Entities;
using System.Threading.Tasks;

namespace APIServices.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BDPServicesContext _context;
        private readonly IUsuariosRepository _userRepository;
        private readonly IRepository<ClienteEmpresa> _clienteEmpRepository;
        private readonly IRepository<EntregasPs> _entregasPSRespository;
        private readonly IRepository<OrdenCompra> _ordenCompra;

        public UnitOfWork(BDPServicesContext context)
        {
            _context = context;
        }

        public IUsuariosRepository UsersRepository => _userRepository ?? new UsuariosRepository(_context);
        public IRepository<ClienteEmpresa> ClienteEmpRepository => _clienteEmpRepository ?? new BaseRepository<ClienteEmpresa>(_context);
        public IRepository<EntregasPs> EntregasPSRespository => _entregasPSRespository ?? new BaseRepository<EntregasPs>(_context);
        public IRepository<OrdenCompra> OrdenCompraRepository => _ordenCompra ?? new BaseRepository<OrdenCompra>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}

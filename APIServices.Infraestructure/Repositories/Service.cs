using APIServices.Domain.Entities;
using APIServices.Domain.Exceptions;
using APIServices.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APIServices.Infraestructure.Repositories
{
    public class Service : IService
    {
        /*private readonly IUsuarios _usuarios;*/ // Posiblemente no se usara 
        //private readonly IRepository<Usuarios> _userRepository;

        private readonly IUnitOfWork _unitofWork;

        public Service(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        #region Usuarios

        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            return await _unitofWork.UsersRepository.GetAll();
        }

        public async Task<Usuarios> GetIdUsuario(int Id)
        {
            var valid = await _unitofWork.UsersRepository.GetById(Id);
            if(valid == null)
            {
                throw new BusinessException("El Usuario No Existe");
            }
            return await _unitofWork.UsersRepository.GetById(Id);
        }

        public async Task<bool> InsertUsuario(Usuarios usuario)
        {
            Expression<Func<Usuarios, bool>> expression = item => item.Usuario == usuario.Usuario || item.Correo == usuario.Correo;
            var listUser = await _unitofWork.UsersRepository.FindByCondition(expression);
            if (listUser.Any(item => item.Usuario == usuario.Usuario))
            {
                throw new BusinessException("El Usuario Ya Existe");
            }
            if (listUser.Any(item => item.Correo == usuario.Correo))
            {
                throw new BusinessException("El Correo Ya Existe, Ingrese otro.");
            }

            await _unitofWork.UsersRepository.Add(usuario);
            int rows = await _unitofWork.SaveChangesAsync();
            return rows > 0;
        }

        // ACTUALIZAR USUARIOS
        public async Task UpdateUsuario(Usuarios usuarios)
        {
            Expression<Func<Usuarios, bool>> expression = item => item.Usuario == usuarios.Usuario || item.Correo == usuarios.Correo;
            var usuario = await _unitofWork.UsersRepository.FindByCondition(expression);
            if (usuario.Where(item => item.Usuario == usuarios.Usuario && item.Id != usuarios.Id).Any())
            {
                throw new BusinessException("Este Usuario Ya Existe");
            }
            if (usuario.Any(item => item.Correo == usuarios.Correo && item.Id != usuarios.Id))
            {
                throw new BusinessException("El Correo Ya Existe");
            }

            await _unitofWork.UsersRepository.Update(usuarios);
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var valid = await _unitofWork.UsersRepository.GetById(id);
            if (valid == null)
            {
                throw new BusinessException("El Usuario No existe");
            }
            await _unitofWork.UsersRepository.Delete(id);

            int rows = await _unitofWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Usuarios> Login(Usuarios usuarios)
        {
            return await _unitofWork.UsersRepository.Login(usuarios);
            
        }

        #endregion

        #region ClienteEmpresa 
        // ========= Parte de ClienteEmpresa ==========

        public Task<IEnumerable<ClienteEmpresa>> GetCliente()
        {
            return _unitofWork.ClienteEmpRepository.GetAll();
        }


        public async Task<ClienteEmpresa> GetIdEmpresa(int IdEmpresa)
        {
            var valid = await _unitofWork.ClienteEmpRepository.GetById(IdEmpresa);
            if (valid == null)
            {
                throw new BusinessException("La Empresa No Existe");
            }
            return await _unitofWork.ClienteEmpRepository.GetById(IdEmpresa);
        }

        public async Task<bool> InsertCliente(ClienteEmpresa cliente)
        {
            Expression<Func<ClienteEmpresa, bool>> expression = item => item.NombreFiscal == cliente.NombreFiscal || item.Correo == cliente.Correo;
            var listUser = await _unitofWork.ClienteEmpRepository.FindByCondition(expression);
            if (listUser.Any(item => item.NombreFiscal == cliente.NombreFiscal))
            {
                throw new BusinessException("La Empresa Ya Existe");
            }
            if (listUser.Any(item => item.Correo == cliente.Correo))
            {
                throw new BusinessException("El Correo Ya Existe");
            }

            await _unitofWork.ClienteEmpRepository.Add(cliente);
            int rows = await _unitofWork.SaveChangesAsync();
            return rows > 0;

        }
        public async Task UpdateCliente(ClienteEmpresa cliente)
        {
            Expression<Func<ClienteEmpresa, bool>> expression = item => item.NombreFiscal == cliente.NombreFiscal || item.Correo == cliente.Correo;
            var empresa = await _unitofWork.ClienteEmpRepository.FindByCondition(expression);
            if (empresa.Where(item => item.NombreFiscal == cliente.NombreFiscal && item.Id != cliente.Id).Any())
            {
                throw new BusinessException("Esta Empresa Ya Existe");
            }
            if (empresa.Any(item => item.Correo == cliente.Correo && item.Id != cliente.Id))
            {
                throw new BusinessException("El Correo Ya Existe");
            }

            await _unitofWork.ClienteEmpRepository.Update(cliente);

        }
        //Eliminar Empresa
        public async Task<bool> DeleteCliente(int IdEmpresa)
        {
            var valid = await _unitofWork.ClienteEmpRepository.GetById(IdEmpresa);
            if (valid == null)
            {
                throw new BusinessException("La Empresa No Existe");
            }
            await _unitofWork.ClienteEmpRepository.Delete(IdEmpresa);

            int rows = await _unitofWork.SaveChangesAsync();
            return rows > 0;
        }
        #endregion


        #region Orden Compra
        public Task<IEnumerable<OrdenCompra>> GetOrden()
        {
            return _unitofWork.OrdenCompraRepository.GetAll();
        }

        public async Task<OrdenCompra> GetIdOrden(int IdOrden)
        {
            var valid = await _unitofWork.OrdenCompraRepository.GetById(IdOrden);
            if (valid == null)
            {
                throw new BusinessException("La orden compra no existe");
            }
            return await _unitofWork.OrdenCompraRepository.GetById(IdOrden);
        }


        //Agregar una nueva Orden Compra
        public async Task<bool> InsertOrden(OrdenCompra ordenCompra)
        {
            Expression<Func<OrdenCompra, bool>> expression = item => item.Folio == ordenCompra.Folio;
            var listOrden = await _unitofWork.OrdenCompraRepository.FindByCondition(expression);
            if (listOrden.Any(item => item.Folio == ordenCompra.Folio))
            {
                throw new Exception("El Folio Ya Existe, Agregue otro");
            }

            await _unitofWork.OrdenCompraRepository.Add(ordenCompra);
            int rows = await _unitofWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task UpdateOrden(OrdenCompra ordenCompra)
        {
            await _unitofWork.OrdenCompraRepository.Update(ordenCompra);
        }

        //Eliminar Orden Compra
        public async Task<bool> DeleteOrden(int IdOrden)
        {
            var valid = await _unitofWork.OrdenCompraRepository.GetById(IdOrden);
            if (valid == null)
            {
                throw new BusinessException("La empresa no existe");
            }
            await _unitofWork.OrdenCompraRepository.Delete(IdOrden);

            int rows = await _unitofWork.SaveChangesAsync();
            return rows > 0;
        }

        #endregion


        #region ENTREGAS PS
        // ========= ENTREGAS PS ==========
        public Task<IEnumerable<EntregasPs>> GetEntregas()
        {
            return _unitofWork.EntregasPSRespository.GetAll();
        }

        public async Task<EntregasPs> GetIdEntregas(int IdEntregas)
        {

            return await _unitofWork.EntregasPSRespository.GetById(IdEntregas);
        }
        public async Task<bool> InsertEntregas(EntregasPs entregas)
        {
            await _unitofWork.EntregasPSRespository.Add(entregas);
            var rows = await _unitofWork.SaveChangesAsync();
            return rows > 0;
        }

        public async Task UpdateEntregas(EntregasPs entregasPs)
        {
            await _unitofWork.EntregasPSRespository.Update(entregasPs);
            //_unitofWork.EntregasPSRespository.Update(entregasPs);
            //await _unitofWork.SaveChangeAsync();
            //return true;
        }
        public async Task<bool> DeleteEntrega(int idEntrega)
        {
            await _unitofWork.EntregasPSRespository.Delete(idEntrega);
            int rows = await _unitofWork.SaveChangesAsync();
            return rows > 0;
        }



        #endregion

    }
}

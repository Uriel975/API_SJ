using APIServices.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIServices.Domain.Services
{
    public interface IService
    {
        #region Usuarios
        Task<IEnumerable<Usuarios>> GetUsuarios();

        Task<Usuarios> GetIdUsuario(int Id);

        Task <bool> InsertUsuario(Usuarios usuario);

        Task UpdateUsuario(Usuarios usuarios);

        Task<bool> DeleteUsuario(int id);

        Task<Usuarios> Login(Usuarios usuarios);
        #endregion

        #region Cliente Empresa
        // ===== Parte de ClienteEmpresa =====
        Task<IEnumerable<ClienteEmpresa>> GetCliente();

        Task<ClienteEmpresa> GetIdEmpresa(int IdEmpresa);

        Task <bool> InsertCliente(ClienteEmpresa cliente);

        Task UpdateCliente(ClienteEmpresa cliente);

        Task<bool> DeleteCliente(int IdEmpresa);
        #endregion


        #region Orden Compra
        // ====== Tareas de ORDEN COMPRAS ======

        Task<IEnumerable<OrdenCompra>> GetOrden();
        Task<OrdenCompra> GetIdOrden(int IdOrden);
        Task<bool> InsertOrden(OrdenCompra ordenCompra);
        Task UpdateOrden(OrdenCompra ordenCompra);
        Task<bool> DeleteOrden(int IdCompra);
        Task<bool> ExisteFolio(string folio);
        #endregion


        #region Entregas PS
        // ====== Parte de las Entregas PS =======

        Task<IEnumerable<EntregasPs>> GetEntregas();

        Task<EntregasPs> GetIdEntregas(int IdEntregas);

        Task<bool> InsertEntregas(EntregasPs entregasPs);

        Task UpdateEntregas(EntregasPs entregas);

        Task<bool> DeleteEntrega(int IdEntregas);

        // Estados
        //Task<bool> ActualizarEstadoEntrega(int IdEntregas, EntregasPs estado);




        #endregion
    }
}
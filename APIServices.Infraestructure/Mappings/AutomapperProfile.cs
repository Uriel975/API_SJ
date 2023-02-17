using APIServices.Domain.DTOs;
using APIServices.Domain.Entities;
using AutoMapper;

namespace APIServices.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Usuarios, UsuariosDto>();
            CreateMap<UsuariosDto, Usuarios>();

            CreateMap<ClienteEmpresa, ClienteEmpresaDto>();
            CreateMap<ClienteEmpresaDto, ClienteEmpresa>();

            CreateMap<EntregasPs, EntregasPSDto>();
            CreateMap<EntregasPSDto, EntregasPs>();

            CreateMap<OrdenCompra, OrdenCompraDto>();
            CreateMap<OrdenCompraDto, OrdenCompra>();


        }

    }
}

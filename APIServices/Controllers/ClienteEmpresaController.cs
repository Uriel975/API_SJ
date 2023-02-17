using APIServices.Domain.DTOs;
using APIServices.Domain.Entities;
using APIServices.Domain.Services;
using APIServices.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteEmpresaController : ControllerBase
    {
        private readonly IService _clienteService;
        private readonly IMapper _mapper;

        public ClienteEmpresaController(IService ClienteEmpresa, IMapper mapper)
        {
            _clienteService = ClienteEmpresa;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            var cliente =await _clienteService.GetCliente();
            var ClienteDto = _mapper.Map<IEnumerable<ClienteEmpresaDto>>(cliente);
            var response = new ApiResponse<IEnumerable<ClienteEmpresaDto>>(ClienteDto);
            return Ok(response);
        }

        [HttpGet("{IdEmpresa}")]
        public async Task<IActionResult> GetId(int IdEmpresa)
        {
            var Cliente = await _clienteService.GetIdEmpresa(IdEmpresa);
            var ClienteDto = _mapper.Map<ClienteEmpresaDto>(Cliente);
            var response = new ApiResponse<ClienteEmpresaDto>(ClienteDto);
            return Ok(response);
        }
        //Crear nueva empresa
        [HttpPost]
        public async Task<IActionResult> InsertCliente(ClienteEmpresaDto cliente)
        {
            var empresa = _mapper.Map<ClienteEmpresa>(cliente);
            var result = await _clienteService.InsertCliente(empresa);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente(int IdEmpresa, ClienteEmpresaDto cliente)
        {
            var empresa = _mapper.Map<ClienteEmpresa>(cliente);
            empresa.Id = IdEmpresa;
            await _clienteService.UpdateCliente(empresa);
            var response = new ApiResponse<bool>(true);
            return Ok(response);


            //var empresa = _mapper.Map<ClienteEmpresa>(cliente);
            //empresa.Id = IdEmpresa;
            //await _clienteService.UpdateCliente(empresa);
            //return Ok(empresa);

        }
        //Eliminar Empresa
        [HttpDelete("{IdEmpresa}")]
        public async Task<IActionResult> DeleteUsuario(int IdEmpresa)
        {
            var result = await _clienteService.DeleteCliente(IdEmpresa);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


    }
}

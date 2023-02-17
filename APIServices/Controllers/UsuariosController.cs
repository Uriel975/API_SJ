using APIServices.Domain.DTOs;
using APIServices.Domain.Entities;
using APIServices.Domain.Services;
using APIServices.Handlers;
using APIServices.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IService _usuariosService;
        private readonly IMapper _mapper;

        public UsuariosController(IService usuariosService, IMapper mapper, IConfiguration config)
        {
            _usuariosService = usuariosService;
            _mapper = mapper;
            _config = config;
        }

        //Recibe todos los usuarios de la BD
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {

            var usuarios = await _usuariosService.GetUsuarios();
            var UsuariosDto = _mapper.Map<IEnumerable<UsuariosDto>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuariosDto>>(UsuariosDto);
            return Ok(response);

        }
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> GetIdUsuario(int idUsuario)
        {

            var usuario = await _usuariosService.GetIdUsuario(idUsuario);
            var UsuarioDto = _mapper.Map<UsuariosDto>(usuario);
            var response = new ApiResponse<UsuariosDto>(UsuarioDto);
            return Ok(response);

        }

        [Route("login/")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UsuariosDto usuariosDTO)
        {
            var usuario = _mapper.Map<Usuarios>(usuariosDTO);
            var result = await _usuariosService.Login(usuario);
            var tokenCreator = new TokenCreatorHandler(_config);
            string token = tokenCreator.TokenCreator(result);
            return Ok(new { token });
        }

        //Crear Nuevo Usuario
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> InsertUsuario(UsuariosDto usuariosDto)
        {
            var usuario = _mapper.Map<Usuarios>(usuariosDto);
            var result = await _usuariosService.InsertUsuario(usuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //Actualizar datos de Usuario
        [HttpPut]
        public async Task<IActionResult> UpdateUsuario(int idUsuario, UsuariosDto usuariosDto)
        {
            var usuario = _mapper.Map<Usuarios>(usuariosDto);
            usuario.Id = idUsuario;
            await _usuariosService.UpdateUsuario(usuario);
            return Ok(usuario);

        }

        //Eliminar Usuario
        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteUsuario(int idUsuario)
        {
            var result = await _usuariosService.DeleteUsuario(idUsuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}

﻿using APIServices.Domain.DTOs;
using APIServices.Domain.Services;
using APIServices.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIServices.Domain.Entities;

namespace APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregasPSController : ControllerBase
    {
        private readonly IService _entregasService;
        private readonly IMapper _mapper;

        public EntregasPSController(IService EntregasPS, IMapper mapper)
        {
            _entregasService = EntregasPS;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetEntregas()
        {
            var entregas = await _entregasService.GetEntregas();
            var entregasDto = _mapper.Map<IEnumerable<EntregasPSDto>>(entregas);
            var response = new ApiResponse<IEnumerable<EntregasPSDto>>(entregasDto);
            return Ok(response);
        }

        [HttpGet("{IdEntrega}")]
        public async Task<IActionResult> GetId(int IdEntrega)
        {
            var entrega = await _entregasService.GetIdEntregas(IdEntrega);
            var entregaDto = _mapper.Map<EntregasPSDto>(entrega);
            var response = new ApiResponse<EntregasPSDto>(entregaDto);
            return Ok(response);
        }
        
        // Agregar Entregas PS
        [HttpPost]
        public async Task<IActionResult> InsertEntregas(EntregasPSDto entregaDto)
        {
            var insert = _mapper.Map<EntregasPs>(entregaDto);
            var result = await _entregasService.InsertEntregas(insert);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }


        // Actualizar Entregas PS
        [HttpPut]
        public async Task<IActionResult> UpdateEntregas(int IdEntrega, EntregasPSDto entregaDto)
        {
            var entrega = _mapper.Map<EntregasPs>(entregaDto);
            entrega.Id = IdEntrega;
            await _entregasService.UpdateEntregas(entrega);
            return Ok(entrega);


        }

        //Eliminar Entrega
        [HttpDelete("{IdEntrega}")]
        public async Task<IActionResult> DeleteEntrega(int IdEntrega)
        {
            var result = await _entregasService.DeleteEntrega(IdEntrega);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }



    }
}
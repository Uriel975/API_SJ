using APIServices.Domain.DTOs;
using APIServices.Domain.Entities;
using APIServices.Domain.Services;
using APIServices.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {
        private readonly IService _OrdenService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;

        public OrdenCompraController(IService ordenService, IMapper mapper, IWebHostEnvironment webHost)
        {
            _OrdenService = ordenService;
            _mapper = mapper;
            _webHost = webHost;

        }

        // Ver las Ordenes de Compra
        [HttpGet]
        public async Task<IActionResult> GetOrden()
        {
            var ordenes =  _OrdenService.GetOrden();
            var OrdenesDto = _mapper.Map<IEnumerable<OrdenCompraDto>>(ordenes);
            for (int i = 0; i < OrdenesDto.Count(); i++)
            {
                OrdenesDto.ElementAt(i).PDFRoute = OrdenesDto.ElementAt(i).PDFRoute == null ? "" : OrdenesDto.ElementAt(i).PDFRoute.Replace("~", Request.Host.Value);
            }
            var response = new ApiResponse<IEnumerable<OrdenCompraDto>>(OrdenesDto);
            return Ok(response); 

        }

        // Buscar por id, pero igual hay que agregar uno de Folio!!
        [HttpGet("{IdOrden}")]
        public async Task<IActionResult> GetIdOrden(int IdOrden)
        {

            var orden = await _OrdenService.GetIdOrden(IdOrden);
            var ordenDto = _mapper.Map<OrdenCompraDto>(orden);
            ordenDto.PDFRoute = ordenDto.PDFRoute == null ? "" :ordenDto.PDFRoute.Replace("~", Request.Host.Value);
            var response = new ApiResponse<OrdenCompraDto>(ordenDto);
            return Ok(response);

        }

        //Crear Nueva orden de compra
        [HttpPost]
        public async Task<IActionResult> InsertOrden([FromForm]OrdenCompraDto ordenDto)
        {
            var orden = _mapper.Map<OrdenCompra>(ordenDto);
            if (await _OrdenService.ExisteFolio(orden.Folio)) return Conflict();
            orden.PDFRoute = ProcessUploadFile(ordenDto.Pdf);
            var result = await _OrdenService.InsertOrden(orden);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // Actualizar Orden Compra
        [HttpPut]
        public async Task<IActionResult> UpdateOrden(int IdOrden, OrdenCompraDto ordenCompraDto)
        {
            var orden = _mapper.Map<OrdenCompra>(ordenCompraDto);
            orden.Id = IdOrden;
            await _OrdenService.UpdateOrden(orden);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        //Eliminar Orden Compra
        [HttpDelete("{IdOrden}")]
        public async Task<IActionResult> DeleteOrden(int IdOrden)
        {
            var result = await _OrdenService.DeleteOrden(IdOrden);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        private string ProcessUploadFile(IFormFile file)
        {
            if (file == null)
            {
                return string.Empty;
            }
            var uploadFolder = Path.Combine(_webHost.WebRootPath, "PDFs");
            var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadFolder, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
            return $"~/PDFs/{fileName}";
        }

    }
}

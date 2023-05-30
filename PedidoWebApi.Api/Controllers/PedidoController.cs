using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Domain;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain.Domain.DTO;
using PedidoWebApi.Services;

namespace PedidoWebApi.Api.Controllers;

[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoRepository pedidoRepository, IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
            _pedidoRepository = pedidoRepository;
        }

        [HttpPost("GetByPedido")]
        public IActionResult GetByPedido([FromBody] Guid PedidoId)
        {
            var pedido = _pedidoService.SearchID(PedidoId);
            if(pedido is null)
            {
                return BadRequest("Pedido não encontrado.");
            }
            return Ok(pedido);
        }

        [HttpPost("Get")]
        public IActionResult Get([FromBody] Guid id)
        {
            try
            {
                Pedido pedido = _pedidoRepository.SearchID(id);
                if (pedido == null)
                    return NotFound();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the request. Message: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] PedidoDTO dto)
        {
            
            Console.WriteLine(dto);
            var pedido =  _pedidoService.Create(dto);
            if(pedido is string p)
            {
                return BadRequest(p);
            }
            return Ok(pedido);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            Pedido pedido = _pedidoService.SearchID(id);
            if (pedido == null)
                return NotFound();

            _pedidoService.Remove(pedido);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] PedidoUpdateDTO pedidoUpdateDTO)
        {
            if (pedidoUpdateDTO == null)
                return BadRequest("Invalid pedido object.");

            var updatedPedido = _pedidoService.Update(pedidoUpdateDTO);
            if (updatedPedido is string p)
                return BadRequest(p);
                

            return Ok(updatedPedido);
        }

}
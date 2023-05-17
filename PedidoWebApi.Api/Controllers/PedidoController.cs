using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Domain;
using PedidoWebApi.Domain.Services;
using PedidoWebApi.Api.Repository;

namespace PedidoWebApi.Api.Controllers;

[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepository _pedidoRepository;

public PedidoController(IPedidoRepository pedidoRepository)
{
    _pedidoRepository = pedidoRepository;
}

[HttpPost("GetByPedido")]
public Pedido GetByPedido(Guid PedidoId)
{
    Pedido pedido = _pedidoRepository.SearchID(PedidoId);
    return pedido;
}

[HttpPost("Get")]
public IActionResult Get(Guid id)
{
    try
    {
        Pedido pedido = _pedidoRepository.SearchID(id);
        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }
    catch (Exception exception)
    {
        return StatusCode(500, "An error occurred while processing the request.");
    }
}

[HttpPost]
public IActionResult Add(Pedido pedido)
{
    if (pedido == null)
        return BadRequest("Invalid pedido object.");

    _pedidoRepository.Create(pedido);
    return Ok();
}

[HttpPost("Produto")]
public IActionResult AddProdutoPedido(Pedido pedido)
{
    throw new NotImplementedException();
}

[HttpDelete]
public IActionResult Delete(Guid id)
{
    Pedido pedido = _pedidoRepository.SearchID(id);
    if (pedido == null)
        return NotFound();

    _pedidoRepository.Remove(pedido);
    return Ok();
}

[HttpPut]
public IActionResult Update(Pedido pedido)
{
    if (pedido == null)
        return BadRequest("Invalid pedido object.");

    Pedido updatedPedido = _pedidoRepository.Update(pedido);
    if (updatedPedido == null)
        return NotFound();

    return Ok(updatedPedido);
}

}
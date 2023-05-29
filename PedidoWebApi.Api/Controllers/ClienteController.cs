using Microsoft.AspNetCore.Mvc;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain.Domain.DTO;
using PedidoWebApi.Services;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Controllers;


[Route("api/[controller]")]
public class ClienteController : ControllerBase
{   
    private readonly IClienteRepository _ClienteRepository;
    private readonly IClienteService _clienteService;    
    public ClienteController(IClienteRepository clienteRepository, IClienteService clienteService)
    {
        _clienteService = clienteService;
        _ClienteRepository = clienteRepository;
    }    
    [HttpPost("GetAll")]
public IActionResult GetAll([FromBody] IEnumerable<Cliente> clientes)
{
    try
    {
        // Cliente criterio = new Cliente();
        // List<Cliente> resultado = _ClienteRepository.GetAllClientes(criterio);

        return Ok();
    }
    catch (Exception ex)
    {
        return BadRequest($"Error to obtain all Clientss: {ex.Message}");
    }
}

[HttpPost("Get")]
public IActionResult Get([FromBody] Guid id)
{
    try
    {
        Cliente cliente = _ClienteRepository.SearchID(id);
        if (cliente != null)
            return Ok(cliente);
        else
            return NotFound($"Cliente ID '{id}' not found.");
    }
    catch (Exception ex)
    {
        return BadRequest($"Error to obtain Clients by ID: {ex.Message}");
    }
}

[HttpPost]
public IActionResult Add ([FromBody] ClienteDTO clienteDTO )
{
    
        Console.WriteLine(clienteDTO);
       var newCliente =  _clienteService.Create(clienteDTO);
        return Ok(newCliente);
    
    
}

[HttpPut]
public IActionResult Update([FromBody] Cliente cliente)
{
    try
    {
        Cliente updatedCliente = _ClienteRepository.Update(cliente);
        if (updatedCliente != null)
            return Ok(updatedCliente);
        else
            return NotFound($"Client ID '{cliente.Id}' not found.");
    }
    catch (Exception ex)
    {
        return BadRequest($"Error to update client: {ex.Message}");
    }
}

[HttpDelete]
public IActionResult Delete([FromBody] Guid id)
{
    try
    {
        Cliente cliente = _ClienteRepository.SearchID(id);
        if (cliente != null)
        {
            _ClienteRepository.Remove(cliente);
            return Ok();
        }
        else
        {
            return NotFound($"Cliente com ID '{id}' não encontrado.");
        }
    }
    catch (Exception ex)
    {
        return BadRequest($"Erro ao excluir cliente: {ex.Message}");
    }
}

}
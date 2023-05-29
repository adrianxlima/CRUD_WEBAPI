using Microsoft.AspNetCore.Mvc;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain.Domain.DTO;
using PedidoWebApi.Services;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Controllers;

[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{       
     private readonly  IProdutoRepository _produtoRepository;
     private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoRepository produtoRepository, IProdutoService produtoService)
    {
        _produtoService = produtoService;
        _produtoRepository = produtoRepository;
    }

    [HttpPost("GetAll")]
    public List<Produto> GetAll()
    {
        return _produtoRepository.GetAll();
    }

    [HttpPost("Get")]
    public Produto Get([FromBody] Guid id)
    {
        return _produtoRepository.SearchID(id);
    }

    [HttpPost]
    public IActionResult Add([FromBody] ProdutoDTO dto)
    {
       var res =  _produtoService.Create(dto);
        return Ok(res);
    }

    [HttpPut]
    public IActionResult Update([FromBody] Produto produto)
    {
        try
        {
            _produtoRepository.Update(produto);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"error: {exception.Message}");
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] Guid id)
    {
        _produtoRepository.Remove(_produtoRepository.SearchID(id));
        return Ok();
    }

}
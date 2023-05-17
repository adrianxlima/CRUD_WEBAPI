using Microsoft.AspNetCore.Mvc;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain.Services;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Controllers;

[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{       
     private readonly  IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpPost("GetAll")]
    public List<Produto> GetAll()
    {
        return _produtoRepository.GetAll();
    }

    [HttpPost("Get")]
    public Produto Get(Guid id)
    {
        return _produtoRepository.SearchID(id);
    }

    [HttpPost]
    public IActionResult Add(Produto produto)
    {
        _produtoRepository.Create(produto);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Produto produto)
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
    public IActionResult Delete(Guid id)
    {
        _produtoRepository.Remove(_produtoRepository.SearchID(id));
        return Ok();
    }

}
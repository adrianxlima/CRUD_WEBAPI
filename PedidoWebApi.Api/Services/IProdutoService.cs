using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain.Domain.DTO;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Services
{
    public interface IProdutoService
    {
        Object Create(ProdutoDTO produtoDTO);
        void Remove(Produto produto);
        Produto Update(ProdutoDTO produtoDTO);
        Produto SearchID(Guid Id);

        List<Produto> GetAll();
        bool Remove(Guid id);
    }
}
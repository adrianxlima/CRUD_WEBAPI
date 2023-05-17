using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public interface IProdutoRepository
    {
            void Create(Produto produto);
            void Remove(Produto produto);
            Produto Update(Produto produto);
            Produto SearchID(Guid Id);
            List<Produto> GetAll();
    }
}
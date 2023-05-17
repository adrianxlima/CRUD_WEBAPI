using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public interface IPedidoRepository
    {
        void Create(Pedido pedido);
        void Remove(Pedido pedido);
        Pedido Update(Pedido pedido);
        Pedido SearchID(Guid Id);

        List<Pedido> GetAll(); 
    }
}
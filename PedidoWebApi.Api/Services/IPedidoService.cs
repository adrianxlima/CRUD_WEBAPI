using PedidoWebApi.Domain.Domain.DTO;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Services
{
    public interface IPedidoService
    {
        Object Create(PedidoDTO pedidoDTO);
        void Remove(Pedido pedido);
        Object Update(PedidoUpdateDTO pedidoUpdateDTO);
        Pedido SearchID(Guid Id);

        List<Pedido> GetAll();
        bool Remove(Guid id);
    }
}
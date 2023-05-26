using ProjetoWebApi.Domain;

namespace PedidoWebApi.Services
{
    public interface IPedidoService
    {
        void Create(Pedido pedido);
        void Remove(Pedido pedido);
        Pedido Update(Pedido pedido);
        Pedido SearchID(Guid Id);

        List<Pedido> GetAll();
        bool Remove(Guid id);
    }
}
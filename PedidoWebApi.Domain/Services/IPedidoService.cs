using ProjetoWebApi.Domain;

namespace PedidoWebApi.Domain.Services
{
    public interface IPedidoService
    {
        void Create(Pedido pedido);
        void Remove(Pedido pedido);
        Pedido Update(Pedido pedido);
        Pedido SearchID(Guid Id);

        List<Pedido> GetAll();  
    }
}
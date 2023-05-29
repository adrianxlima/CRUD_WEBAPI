using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain.Domain.DTO;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public interface IPedidoRepository
    {
        Pedido Create(Pedido pedido);
        void Remove(Pedido pedido);
        Pedido? Update(Guid idPedido, List<PedidoProduto>pedidoProdutos);
        Pedido SearchID(Guid Id);
        string UpdatePayment(PaymentDTO paymentDTO);
        List<PedidoProduto> addRangePedidoProduto(List<PedidoProduto> pedidoProdutos);
        

        List<Pedido> GetAll(); 
    }
}
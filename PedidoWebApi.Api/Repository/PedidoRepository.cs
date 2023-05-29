using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PedidoWebApi.Api.Infrastructure;
using PedidoWebApi.Domain.Domain.DTO;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;


        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Pedido Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return pedido;
        }

        public List<Pedido> GetAll()
        {
            return _context.Pedidos.ToList();
        }

        public void Remove(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }

        public Pedido SearchID(Guid Id)
        {
            return _context.Pedidos.FirstOrDefault(p => p.Id == Id)!;
        }

        public Pedido? Update(Guid idPedido, List<PedidoProduto>pedidoProdutos)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == idPedido);
            if(pedido == null)
            {
                return null;
            }

            var pedidoprodutos = _context.PedidoProdutos.Include(p => p.Produto).Where(p => p.IdPedido == pedido.Id).ToList();
            _context.PedidoProdutos.RemoveRange(pedidoprodutos);
            pedido.PedidoProdutos = pedidoProdutos;
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
            return pedido;
        }
        public string UpdatePayment(PaymentDTO paymentDTO)
        {
            Console.WriteLine(paymentDTO);
            var order = _context.Pedidos.FirstOrDefault(p => p.Id == paymentDTO.IdPedido);
            if (order is not null)
            {

                if (order.pagamento)
                {
                    return "Já esta pago.";
                }
                order.pagamento = true;
                _context.SaveChanges();
                return "O Pedido está pago.";
            }
            return "Pedido não encontrado";
        }
        public List<PedidoProduto> addRangePedidoProduto(List<PedidoProduto> pedidoProdutos)
        {
            _context.PedidoProdutos.AddRange(pedidoProdutos);
            _context.SaveChanges();
            return pedidoProdutos;
        }

    }
}
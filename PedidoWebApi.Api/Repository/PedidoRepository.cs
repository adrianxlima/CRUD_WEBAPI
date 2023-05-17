using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Api.Infrastructure;
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

        public void Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
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
            return _context.Pedidos.FirstOrDefault(p => p.Id == Id);
        }

        public Pedido Update(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
            return pedido;
        }


    }
}
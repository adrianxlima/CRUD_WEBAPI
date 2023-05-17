using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Api.Infrastructure;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Cliente cliente)
        { 
            _context.Add(cliente);
            _context.SaveChanges();
        }
        public IEnumerable<Cliente> GetClientes(Guid id)
        {
            return _context.Clientes.ToList();
        }

        public void Remove(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();
        }
        public Cliente SearchID(Guid Id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(c => c.Id == Id);
            return cliente;
        }
        public Cliente Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }
        public List<Cliente> GetAllClientes(Cliente cliente)
        {
            IQueryable<Cliente> query = _context.Clientes;

            if (cliente.Id != Guid.Empty)
                query = query.Where(c => c.Id == cliente.Id);

            if (!string.IsNullOrEmpty(cliente.Nome))
                query = query.Where(c => c.Nome == cliente.Nome);

            List<Cliente> resultado = query.ToList();

            return resultado;
        }
    }
}
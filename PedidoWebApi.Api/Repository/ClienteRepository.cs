using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Api.Infrastructure;
using PedidoWebApi.Domain.Domain.DTO;
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

        public ClienteDTO Create(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
            return new ClienteDTO()
            {
                Nome = cliente.Nome,
                id = cliente.Id
            };
        }
        public List<Cliente> GetClientes()
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
            var cliente =  _context.Clientes.FirstOrDefault(c => c.Id == Id)!;
            return cliente;
        }
        public Cliente Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }
    }
}
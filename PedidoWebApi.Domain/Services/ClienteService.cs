using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Domain.Services
{
    public class ClienteService : IClienteService
    {   
        public List<Cliente> Clientes{get; set;} = new()
        {
            new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Nome1",
            },
             new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Nome2",
            },
             new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Nome3",
            }
        };

        public void Create(Cliente cliente)
        {   
            Clientes.Add(cliente);
        }

        public List<Cliente> GetAll()
        {
            return Clientes;
        }

        public void Remove(Cliente cliente)
        {
            Clientes.Remove(cliente);
        }
        public Cliente SearchID(Guid Id)
        {   
            Cliente cliente = new Cliente();
            try
            {
                cliente = Clientes.Find(c => c.Id == Id);
                
            }
            catch(Exception exception)
            {
                Console.WriteLine($"error: {exception.Message}");
            }

            return cliente;
        }
        public Cliente Update(Cliente cliente)
        {
            Clientes[Clientes.FindIndex(p => p.Id == cliente.Id)] = cliente;
            return Clientes[Clientes.FindIndex(p => p.Id == cliente.Id)];
        }
    }
}
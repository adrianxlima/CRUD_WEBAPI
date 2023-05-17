using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes(Guid id);
        void Create(Cliente cliente);
        void Remove(Cliente cliente);
        Cliente Update(Cliente cliente);
        Cliente SearchID(Guid Id);
        List<Cliente> GetAllClientes(Cliente cliente);
    }
}
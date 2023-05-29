using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain.Domain.DTO;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public interface IClienteRepository
    {
        List<Cliente> GetClientes();
        ClienteDTO Create(Cliente cliente);
        void Remove(Cliente cliente);
        Cliente Update(Cliente cliente);
        Cliente SearchID(Guid Id);
    }
}
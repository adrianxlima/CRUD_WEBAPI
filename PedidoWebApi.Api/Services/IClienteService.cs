using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain.Domain.DTO;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Services
{
    public interface IClienteService
    {   
        ClienteDTO Create(ClienteDTO clienteDTO);
        Boolean Remove(Cliente cliente);
        Cliente Update(Cliente cliente);
        Cliente SearchID(Guid Id);
        List<Cliente> GetAll();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain.Domain.DTO;
using PedidoWebApi.Services;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public ClienteDTO Create(ClienteDTO clienteDTO)
        {
            var clientes = _clienteRepository.GetClientes()
                    .Find(p => p.Nome == clienteDTO.Nome);

            if (clientes is null)
            {
                var newCliente = _clienteRepository.Create(new Cliente()
                {
                    Nome = clienteDTO.Nome,
                    Senha = clienteDTO.Senha
                });
                Console.WriteLine(newCliente);
                return new ClienteDTO()
                {
                    id = newCliente.id,
                    Nome = newCliente.Nome,
                };
            }
            return null!;
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetClientes();
        }

        public Boolean Remove(Cliente cliente)
        {
            var selectCliente = _clienteRepository.SearchID(cliente.Id);
            if(selectCliente is not null)
            {
               _clienteRepository.Remove(cliente);
                return true;
            }
            return false;
        }

        public Cliente SearchID(Guid Id)
        {
            var cliente = _clienteRepository.SearchID(Id);
            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            var clienteUpdate = _clienteRepository.SearchID(cliente.Id);
            if (clienteUpdate is not null)
            {
                _clienteRepository.Update(cliente);
            }
            return null!;
        }
    }
}
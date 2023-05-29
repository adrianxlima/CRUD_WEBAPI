using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain.Domain.DTO;
using PedidoWebApi.Domain.Domain.Validators;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IClienteRepository _ClienteRepository;
        private readonly IProdutoRepository _ProdutoRepository;

        public PedidoService(
        IPedidoRepository pedidoRepository,
        IClienteRepository clienteRepository,
        IProdutoRepository ProdutoRepository)
        {
            _ProdutoRepository = ProdutoRepository;
            _ClienteRepository = clienteRepository;
            _repository = pedidoRepository;
        }

        public Object Create(PedidoDTO dto)
        {
            Console.WriteLine(dto);
            var cliente = _ClienteRepository.SearchID(dto.ClienteId);
            Console.WriteLine(cliente);
            if (cliente is null)
            {
                return "Id do usuario invalido.";
            }
            decimal ValorTotal = 0;
            var pedido = new Pedido()
            {
                Id = Guid.NewGuid(),
                idCliente = cliente.Id,
                ValorTotal = ValorTotal,
            };
             List<PedidoProduto> lista = new();
            
            foreach (var produtoId in dto.Products)
            {
                var produto = _ProdutoRepository.SearchID(produtoId);
                if (produto is null)
                {
                    return "Produto invalido.";
                }
                ValorTotal += produto.Valor;
                var pedidoProdutos = new PedidoProduto()
                {
                    IdPedido = pedido.Id,
                    ValorTotalLinha = produto.Valor,
                    Quantidade = 1,
                    idProduto = produtoId
                };
                lista.Add(pedidoProdutos);
            }
            pedido.ValorTotal = ValorTotal;

            var pedidoRetorno =  _repository.Create(pedido);
            var pedidoProdutosRetorno = _repository.addRangePedidoProduto(lista);
            pedidoRetorno.PedidoProdutos = pedidoProdutosRetorno;
            return pedidoRetorno;
            
        }


        public List<Pedido> GetAll()
        {
            return new List<Pedido>();
        }

        public void Remove(Pedido pedido)
        {
            _repository.Remove(pedido);
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }


        public Pedido SearchID(Guid Id)
        {
            var pedido =  _repository.SearchID(Id);
            return pedido;
        }
        public Object Update(PedidoUpdateDTO pedidoUpdateDTO)
        {
           var pedidoUpdateDTOValidation = new PedidoUpdtadeDTOValidation().Validate(pedidoUpdateDTO);
           if(!pedidoUpdateDTOValidation.IsValid)
           {
                return pedidoUpdateDTOValidation.ToString();
           }
           decimal ValorTotal = 0;
           List<PedidoProduto>lista = new();
           foreach (Guid id in pedidoUpdateDTO.Products)
           {
                var produto = _ProdutoRepository.SearchID(id);
                if (produto is null)
                {
                    return "Produto invalido.";
                }
                ValorTotal += produto.Valor;
                var pedidoProdutos = new PedidoProduto()
                {
                    IdPedido = pedidoUpdateDTO.Idpedido,
                    ValorTotalLinha = produto.Valor,
                    Quantidade = 1,
                    idProduto = id
                };
                lista.Add(pedidoProdutos);
           }
           var pedidoRetorno = _repository.Update(pedidoUpdateDTO.Idpedido,lista);
           if(pedidoRetorno == null)
           {
                return "Pedido não encontrado.";
           }
           
            return pedidoRetorno;
        }
    }
}
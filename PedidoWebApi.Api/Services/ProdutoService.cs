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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Object Create(ProdutoDTO dto)
        {
            var validator = new ProdutoDTOValidation()
                .Validate(dto);

            if (validator.IsValid)
            {
                return _repository.Create(
                  new Produto()
                  {
                    Nome = dto.Nome,
                    Valor = dto.Valor,
                    Quantidade = dto.Quantidade
                  }
                );
            }
            
            return validator.ToString();
        }
        public List<Produto> GetAll()
        {
            return new List<Produto>();
        }

        public void Remove(Produto produto)
        {
            _repository.Remove(produto);
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        public Produto SearchID(Guid Id)
        {
            var produto = _repository.SearchID(Id);
            return produto;
        }

        public Produto Update(ProdutoDTO produtoDTO)
        {
            var produto = _repository.SearchID(produtoDTO.id);
            if(produto is not null)
            {
                _repository.Update(
                    new Produto()
                  {
                    Nome = produtoDTO.Nome,
                    Valor = produtoDTO.Valor,
                    Quantidade = produtoDTO.Quantidade
                  });
                
            }
            return null!;
        }
    }
}
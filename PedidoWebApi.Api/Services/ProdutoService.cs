using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Services
{
    public class ProdutoService : IProdutoService
    {   
        public List<Produto> Produtos{get; set;} = new()
        {
            new Produto
            {
                Id = Guid.NewGuid(),
                Valor = 10,
                Nome = "NAME1",
                
            },
             new Produto
            {
                Id = Guid.NewGuid(),
                Valor = 10,
                Nome = "NAME1",
            },
             new Produto
            {
                Id = Guid.NewGuid(),
                Valor = 10,
                Nome = "NAME1",
            }
        };

        public void Create(Produto produto)
        {
            Produtos.Add(produto);
        }
        public List<Produto> GetAll()
        {
            return Produtos;
        }

        public void Remove(Produto produto)
        {
            Produtos.Remove(produto);
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        public Produto SearchID(Guid Id)
        {   
            try
           { 
            Produto produto = Produtos.Where(Produto => Produto.Id == Id).First();
            return produto;
           }
           catch(Exception exception)
           {
                return null;
           }
           
        }

        public Produto Update(Produto produto)
        {
           try
           { 
           Produtos[Produtos.FindIndex(p => p.Id == produto.Id)] = produto;
           return Produtos[Produtos.FindIndex(p => p.Id == produto.Id)];
            
           }
           catch(Exception exception)
           {
                return produto;

           }
           
        }
        List<Produto> IProdutoService.GetAll()
        {
            throw new NotImplementedException();
        }

        Produto IProdutoService.SearchID(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
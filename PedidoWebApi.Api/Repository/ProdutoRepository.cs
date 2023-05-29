using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Api.Infrastructure;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {   
       private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Produto Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public List<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public void Remove(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public Produto SearchID(Guid Id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == Id)!;
        }

        public Produto Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return produto;
        }


    }
}
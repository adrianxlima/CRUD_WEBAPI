using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Api.Infrastructure
{   
    
    public class ApplicationDbContext : DbContext
    {   
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<Produto> Produtos {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost; Port=5022; Database=postgres; Uid=postgres; Pwd=Mydb");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoProduto>()
                .HasKey(la => new { la.IdPedido, la.idProduto });

            modelBuilder.Entity<Pedido>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<Produto>()
                .HasKey(e => e.Id);    
            
            modelBuilder.Entity<Cliente>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.PedidoProdutos)
                .WithOne(p => p.Pedido)
                .HasForeignKey(p => p.idProduto);
             modelBuilder.Entity<Produto>()
                .HasMany(p => p.PedidoProdutos)
                .WithOne(p => p.Produto)
                .HasForeignKey(p => p.idProduto);     
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.pedidos)
                .WithOne(p => p.cliente)
                .HasForeignKey(p => p.idCliente);
            
               
        }
    }
}
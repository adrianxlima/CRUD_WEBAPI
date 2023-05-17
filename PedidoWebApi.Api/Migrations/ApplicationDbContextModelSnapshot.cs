﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PedidoWebApi.Api.Infrastructure;

#nullable disable

namespace PedidoWebApi.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjetoWebApi.Domain.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.Property<Guid>("idCliente")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("idCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.PedidoProduto", b =>
                {
                    b.Property<Guid>("IdPedido")
                        .HasColumnType("uuid");

                    b.Property<Guid>("idProduto")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorTotalLinha")
                        .HasColumnType("numeric");

                    b.HasKey("IdPedido", "idProduto");

                    b.HasIndex("idProduto");

                    b.ToTable("PedidoProduto");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Cliente", b =>
                {
                    b.HasOne("ProjetoWebApi.Domain.Cliente", null)
                        .WithMany("Clientes")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Pedido", b =>
                {
                    b.HasOne("ProjetoWebApi.Domain.Pedido", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("PedidoId");

                    b.HasOne("ProjetoWebApi.Domain.Cliente", "cliente")
                        .WithMany("pedidos")
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.PedidoProduto", b =>
                {
                    b.HasOne("ProjetoWebApi.Domain.Pedido", "Pedido")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("idProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoWebApi.Domain.Produto", "Produto")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("idProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Produto", b =>
                {
                    b.HasOne("ProjetoWebApi.Domain.Produto", null)
                        .WithMany("Produtos")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Cliente", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("pedidos");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Pedido", b =>
                {
                    b.Navigation("PedidoProdutos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Produto", b =>
                {
                    b.Navigation("PedidoProdutos");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}

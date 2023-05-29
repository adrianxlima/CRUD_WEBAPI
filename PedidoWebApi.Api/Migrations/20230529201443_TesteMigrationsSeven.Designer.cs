﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PedidoWebApi.Api.Infrastructure;

#nullable disable

namespace PedidoWebApi.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230529201443_TesteMigrationsSeven")]
    partial class TesteMigrationsSeven
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PedidoWebApi.Domain.Domain.Enum.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdPedido")
                        .HasColumnType("uuid");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.Property<Guid>("idCliente")
                        .HasColumnType("uuid");

                    b.Property<bool>("pagamento")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

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

                    b.ToTable("PedidoProdutos");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Pedido", b =>
                {
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
                        .HasForeignKey("IdPedido")
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

            modelBuilder.Entity("ProjetoWebApi.Domain.Cliente", b =>
                {
                    b.Navigation("pedidos");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Pedido", b =>
                {
                    b.Navigation("PedidoProdutos");
                });

            modelBuilder.Entity("ProjetoWebApi.Domain.Produto", b =>
                {
                    b.Navigation("PedidoProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}

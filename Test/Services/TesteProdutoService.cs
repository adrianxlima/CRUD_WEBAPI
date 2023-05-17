using System;
using Bogus;
using FluentAssertions;
using PedidoWebApi.Domain.Services;
using PedidoWebApi.Api.Infrastructure;
using ProjetoWebApi.Domain;
using Xunit;

namespace Test.Services
{
    public class TesteProdutoService
    {
        private readonly IProdutoService _service;
        private readonly ApplicationDbContext _context;
        private readonly Faker _faker;

        public TesteProdutoService(IProdutoService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public void UpdateProduct_Should_UpdateProductDetails()
        {
            // Arrange
            Produto produto = new Produto()
            {
                Id = Guid.NewGuid(),
                Nome = _faker.Commerce.ProductName(),
                Preco = _faker.Random.Decimal(10, 100),
                Quantidade = _faker.Random.Int(1, 100)
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            // Act
            produto.Nome = "Novo Nome";
            produto.Preco = 99.99m;
            produto.Quantidade = 50;

            _service.Update(produto);

            // Assert
            var updatedProduct = _service.SearchID(produto.Id);
            updatedProduct.Should().NotBeNull();
            updatedProduct.Nome.Should().Be("Novo Nome");
            updatedProduct.Preco.Should().Be(99.99m);
            updatedProduct.Quantidade.Should().Be(50);
        }

        [Fact]
        public void RemoveProduct_Should_RemoveProductFromDatabase()
        {
            // Arrange
            Produto produto = new Produto()
            {
                Id = Guid.NewGuid(),
                Nome = _faker.Commerce.ProductName(),
                Preco = _faker.Random.Decimal(10, 100),
                Quantidade = _faker.Random.Int(1, 100)
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            // Act
            bool result = _service.Remove(produto.Id);

            // Assert
            result.Should().Be(true);

            var removedProduct = _service.SearchID(produto.Id);
            removedProduct.Should().BeNull();
        }
    }
}

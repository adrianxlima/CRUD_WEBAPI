using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using ProjetoWebApi.Domain;
using Xunit;

namespace Test.Domain
{
    public class TestePedidoProduto
    {
        private Faker faker = new Faker("pt_BR");

        private Produto produto;

        public TestePedidoProduto()
        {

            produto = new Produto() { Id = Guid.NewGuid(), Nome = faker.Commerce.ProductName(), Valor = faker.Random.Decimal(1, 10) };
        }
        [Fact]
        public void TesteValorLinhaTotal()
        {
            int quantidade = faker.Random.Int(1, 10);
            PedidoProduto pedidoProduto = new PedidoProduto(quantidade, produto);
            decimal valorLinhaTeste = quantidade * produto.Valor;
            pedidoProduto.ValorTotalLinha.Should().Be(valorLinhaTeste);
        }
    }
}
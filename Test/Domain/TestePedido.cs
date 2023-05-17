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
    public class TestePedido
    {
        private Faker faker = new Faker("pt_BR");

        private List<Produto> listProducts = new();

        private List<PedidoProduto> listPedidoProduto = new();
        private Cliente cliente;
        public TestePedido()
        {   
            for (int i = 0; i < 10; i++)
            {
                listProducts.Add(new Produto() { Id = Guid.NewGuid(), Nome = faker.Commerce.ProductName(), Valor = faker.Random.Decimal(1, 10) });
            }
            foreach (Produto produto in listProducts)
            {
                listPedidoProduto.Add(new PedidoProduto(1, produto));
            }
            cliente = new Cliente() { Id = Guid.NewGuid(), Nome = faker.Name.FullName(), Senha = faker.Random.String2(10) };
        }
        [Fact]
        public void ValorTotalTest()
        {
            decimal valorTotal = 0;
            Pedido pedido = new Pedido();
            foreach (PedidoProduto pedidoProduto in listPedidoProduto)
            {
                valorTotal += pedidoProduto.ValorTotalLinha;
            }
            pedido.ValorTotal.Should().Be(valorTotal);

        }
    }
}
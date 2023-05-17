using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using PedidoWebApi.Api.Infrastructure;
using PedidoWebApi.Domain.Services;
using ProjetoWebApi.Domain;
using Xunit;

namespace Test.Services
{
    public class TestePedidoService
    {
         private readonly IPedidoService _service;
        private readonly ApplicationDbContext _context;
        private Faker faker = new Faker("pt_BR");
        public  TestePedidoService(IPedidoService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [Fact]
        public void UpdateOrder_Should_UpdateUserDetails(int OrderId, string OrderName)
        {
            // Arrange
            var userService = new ClienteService();
            var user = new ClienteService { Id = OrderId, Name = OrderName};

            // Act
            userService.Update(user);

            // Assert
            var updatedUser = userService.SearchID(OrderId);
            Assert.Equal(OrderName, updatedUser);
            Assert.Equal(OrderId, updatedUser);
        }
        [Fact]
        public void DeletClient()
        {
            Pedido pedido = new Pedido()
            {
                Id = Guid.NewGuid(),
                Nome = faker.Name.FullName(),
                Senha = faker.Random.String2(10),
            };
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            Boolean result_1 = _service.Remove(pedido.Id);
            result_1.Should().Be(true);
            Boolean Result2 = _service.Remove(Guid.NewGuid());
            Result2.Should().Be(false);
        }  
    }
}
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
    public class TesteClienteService
    {
        private readonly IClienteService _service;
        private readonly ApplicationDbContext _context;
        private Faker faker = new Faker("pt_BR");
        public TesteClienteService(IClienteService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }
        [Fact]
        public void DeletClient()
        {
            Cliente cliente = new Cliente()
            {
                Id = Guid.NewGuid(),
                Nome = faker.Name.FullName(),
                Senha = faker.Random.String2(10),
            };
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            Boolean result_1 = _service.Remove(cliente.Id);
            result_1.Should().Be(true);
            Boolean Result2 = _service.Remove(Guid.NewGuid());
            Result2.Should().Be(false);
        }
        [Fact]
        public void UpdateUser_Should_UpdateUserDetails(int userId, string userName, int userAge)
        {
            // Arrange
            var userService = new ClienteService();
            var user = new ClienteService { Id = userId, Name = userName, Age = userAge };

            // Act
            userService.Update(user);

            // Assert
            var updatedUser = userService.SearchID(userId);
            Assert.Equal(userName, updatedUser);
            Assert.Equal(userAge, updatedUser);
        }   
    }
}
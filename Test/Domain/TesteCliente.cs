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
    public class TesteCliente
    {
         private Faker faker = new Faker("pt_BR");

        [Fact]
        public void TesteCriptoPassword()
        {
            string senha = faker.Random.String2(10);
            Cliente cliente = new Cliente();
            cliente.Senha = senha;
            senha.Should().NotBe(cliente.Senha);
        }
    }
}
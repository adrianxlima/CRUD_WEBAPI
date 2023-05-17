using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PedidoWebApi.Api.Infrastructure;
using Xunit;

namespace Test.Infrastructure
{
    public class MockApplicationDbContext : ApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("FinancialAccountInMemory");
        }
    }
}
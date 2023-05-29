using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain
{
    public class CreditCard
    {
        public decimal Amount { get; set; }
        public required string CardNumber { get; set; }
        public required string CardName { get; set; }
        public required string Expiration { get; set; }
        public required string CVV { get; set; }
    }
}
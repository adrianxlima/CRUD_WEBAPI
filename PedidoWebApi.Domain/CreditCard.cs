using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain
{
    public class CreditCard
    {
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class PaymentDTO
    {

        public CreditCard? Card {get; set;}
        public Guid IdPedido { get; set; }
        public required String Method { get; set; } 
    }
}
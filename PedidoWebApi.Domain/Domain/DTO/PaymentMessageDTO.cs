using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class PaymentMessageDTO
    {
        public Guid IdPedido { get; set; }
        public Guid IdPayment { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class PaymentDTO
    {
        public Guid IdPedido { get; set; }
        public String Method { get; set; } = "";
    }
}
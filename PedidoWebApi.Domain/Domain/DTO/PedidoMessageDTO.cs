using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class PedidoMessageDTO
    {
        public Guid Id { get; set; }
        public Guid idCliente { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
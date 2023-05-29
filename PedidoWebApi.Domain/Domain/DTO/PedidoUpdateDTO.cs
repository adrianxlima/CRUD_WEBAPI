using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class PedidoUpdateDTO : PedidoDTO
    {
        public Guid Idpedido {get; set;}

    }
}
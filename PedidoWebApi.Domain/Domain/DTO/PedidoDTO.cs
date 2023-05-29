using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class PedidoDTO
    {
        public required Guid ClienteId {get; set;}
        public required List<Guid> Products {get; set;}
        
    }
}
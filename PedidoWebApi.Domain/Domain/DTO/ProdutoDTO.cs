using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class ProdutoDTO
    {
        public Guid id {get; set;}
        public required String Nome {get; set;}
        public int Quantidade {get; set;}
        public Decimal Valor {get; set;}
    }
}
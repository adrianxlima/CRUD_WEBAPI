using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class ProdutoUpdateDTO : ProdutoDTO
    {
        public Guid Idproduto {get; set;}
    }
}
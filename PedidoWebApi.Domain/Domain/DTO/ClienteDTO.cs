using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class ClienteDTO
    {
        public String Nome { get; set; } = null!;
        public Guid id { get; set; }
        public string Senha {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Domain.Services
{
    public class PedidoService : IPedidoService
    {
         public List<Pedido> Pedidos{get; set;} = new()
        {
            new Pedido
            {
                Id = Guid.NewGuid(),
                Valor = 10,
                
            },
             new Pedido
            {
                Id = Guid.NewGuid(),
                Valor = 10,
            },
             new Pedido
            {
                Id = Guid.NewGuid(),
                Valor = 10,
            }
        };

        public void Create(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        public List<Pedido> GetAll()
        {
            return Pedidos;
        }

        public void Remove(Pedido pedido)
        {
            Pedidos.Remove(pedido);
        }

        public Pedido SearchID(Guid Id)
        {   
            try
            {
                Pedido Pedido = Pedidos.Where(Pedido => Pedido.Id == Id).First();
                return Pedido;
            }
            catch(Exception exception)
            {
                return null;
            }
            
        }

        public Pedido Update(Pedido pedido)
        {   try{
            Pedidos[Pedidos.FindIndex(p => p.Id == pedido.Id)] = pedido;
            return Pedidos[Pedidos.FindIndex(p => p.Id == pedido.Id)];
            }
            catch(Exception exception)
            {
                return null;
            }
        }
    }
}
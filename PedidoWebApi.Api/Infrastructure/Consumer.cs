using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Api.Infrastructure
{
    public class Consumer : IConsumer
    {
        public void Consume(PaymentMessageDTO paymentMessageDTO)
        {
            throw new NotImplementedException();
        }

        public void MessageOrder(PedidoMessageDTO pedidoMessageDTO)
        {
            throw new NotImplementedException();
        }
    }
}
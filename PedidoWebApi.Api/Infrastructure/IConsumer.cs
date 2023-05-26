using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Api.Infrastructure
{
    public interface IConsumer
    {
        void Consume(PaymentMessageDTO paymentMessageDTO);
        void MessageOrder(PedidoMessageDTO pedidoMessageDTO);
    }
}
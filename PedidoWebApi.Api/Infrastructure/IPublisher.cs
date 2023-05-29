using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Api.Infrastructure
{
    public interface IPublisher
    {
        void Publish(PaymentDTO dto);
    }
}
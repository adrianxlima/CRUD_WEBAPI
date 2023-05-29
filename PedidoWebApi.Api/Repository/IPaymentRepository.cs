using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain;
using PedidoWebApi.Domain.Domain.Enum;

namespace PedidoWebApi.Api.Repository
{
    public interface IPaymentRepository
    {
        Payment AddPayment(Payment payment);
        
        Payment GetPaymentById(Guid id);
    }
}
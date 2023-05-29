using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Services
{
    public interface IPaymentService
    {
         
         string CheckPaymentStatus(Guid id);
        Object MakePayment(PaymentDTO paymentDTO);
    }
}
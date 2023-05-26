using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain;

namespace PedidoWebApi.Services
{
    public interface IPaymentService
    {
         void MakePayment(CreditCard creditCard);
         string CheckPaymentStatus();
    }
}
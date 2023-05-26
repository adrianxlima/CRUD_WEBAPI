using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Domain;

namespace PedidoWebApi.Api.Repository
{
    public interface IPaymentRepository
    {
        void AddPayment(CreditCard creditCard);
        void GetPaymentById(Guid id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidoWebApi.Api.Infrastructure;
using PedidoWebApi.Domain;
using PedidoWebApi.Domain.Domain.Enum;

namespace PedidoWebApi.Api.Repository
{
    public class PaymentRepository : IPaymentRepository
    {   
         private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPayment(CreditCard creditCard)
        {
            throw new NotImplementedException();
        }

        public Payment GetPaymentById(Guid id)
        {
            return _context.payments.FirstOrDefault(p => p.Id == id);
        }

    }
}
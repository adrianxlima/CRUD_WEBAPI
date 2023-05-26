using PedidoWebApi.Api.Infrastructure;
using PedidoWebApi.Api.Infrastructure.MessageQueue;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Services
{
    public class PaymentService : IPaymentService
    {   
        private readonly IPublisher _publisher;
        private readonly IPaymentRepository _paymentRepository;
        
        private const string queueName = "Pay";
        public PaymentService(IPaymentRepository paymentRepository, IPublisher publisher)
        {
            _paymentRepository = paymentRepository;
            _publisher = publisher;
        }
        public void MakePayment(CreditCard creditCard)
        {                   
            CreditCardValidation creditCardValidation = new CreditCardValidation();
            var resultValidation = creditCardValidation.Validate(creditCard);
            if(resultValidation.IsValid)
            {
                
            }
        }

        public string CheckPaymentStatus()
        {
            throw new NotImplementedException();
        }
    }
}
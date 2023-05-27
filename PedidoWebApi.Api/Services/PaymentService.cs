using PedidoWebApi.Api.Infrastructure;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Services
{
    public class PaymentService : IPaymentService
    {   
        private readonly IPublisher _publisher;
        private readonly IPaymentRepository _paymentRepository;
        
        
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

        public string CheckPaymentStatus(Guid id)
        {
            var payment = _paymentRepository.GetPaymentById(id);
            if (payment == null)
            {
                return "Nenhum pagamento foi encontrado com esse Id.";
            }
            return $"Detalhes do pagamento:\nId: {payment.Id}\nValor: {payment.Valor}\nId do Pedido: {payment.IdPedido}\nMétodo: {payment.Method}";
        }


    }
}
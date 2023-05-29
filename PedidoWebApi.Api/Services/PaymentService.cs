using Newtonsoft.Json;
using PedidoWebApi.Api.Infrastructure;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain;
using PedidoWebApi.Domain.Domain.DTO;
using PedidoWebApi.Domain.Domain.Enum;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PedidoWebApi.Services
{
    public class PaymentService : IPaymentService
    {   

        private readonly IPaymentRepository _paymentRepository;
        private readonly IPedidoRepository _pedidoRepository;
        
        
        public PaymentService(IPaymentRepository paymentRepository, IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _paymentRepository = paymentRepository;
        }
        public Object MakePayment(PaymentDTO paymentDTO)
        {  
            Publisher publishi = new Publisher();
            var pedido = _pedidoRepository.SearchID(paymentDTO.IdPedido);
            
            if(pedido is not null)
            {
                if(paymentDTO.Card is not null)
                {
                    var creditCardValidation = new CreditCardValidation().Validate(paymentDTO.Card);
                    if(creditCardValidation.IsValid)
                    {
                        publishi.Publish(paymentDTO);
                        return true;
                    }
                        
                    else
                    {
                        Console.WriteLine(creditCardValidation.ToString());
                        return creditCardValidation.ToString()!;
                    }
                }
                else{
                    return "O cartão não existe.";
                }
            }
            else
            {
                return "O pedido não pode ser nulo";
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
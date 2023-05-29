using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PedidoWebApi.Domain.Domain.DTO;
using PedidoWebApi.Services;

namespace PedidoWebApi.Api.Controllers
{
    [ApiController]
    [Route("Payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _iPaymentService;
        public PaymentController(IPaymentService iPaymentService)
        {
            _iPaymentService = iPaymentService;
        }
        [HttpPost]
        public IActionResult Payment([FromBody] PaymentDTO dTO)
        {   
                if (dTO.IdPedido == Guid.Empty)
            {
                return BadRequest("ID do pedido inválido.");
            }

            // Verificar se o método de pagamento é válido
            if (string.IsNullOrEmpty(dTO.Method))
            {
                return BadRequest("Método de pagamento inválido.");
            }

            // Lógica para processar o pagamento
            try
            {
                var payment = _iPaymentService.MakePayment(dTO);
                if(payment is string p)
                {
                    Console.WriteLine(p);
                    return BadRequest(p.ToString());
                }
                
                return Ok("Pagamento processado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, $"Erro ao processar o pagamento: {ex.Message}");
            }
        }

        
        [HttpPost]
        [Route("GetOne")]
        public IActionResult GetOne([FromBody] Guid id)
        {
           throw new NotImplementedException();
        }
    }
}
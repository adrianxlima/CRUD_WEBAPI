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
        public IActionResult Payment(PaymentDTO dTO)
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
                return Ok("Pagamento processado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar o pagamento: {ex.Message}");
            }
        }

        
        [HttpPost]
        [Route("GetOne")]
        public IActionResult GetOne(Guid id)
        {
           throw new NotImplementedException();
        }
    }
}
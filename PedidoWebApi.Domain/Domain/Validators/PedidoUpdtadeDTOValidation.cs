using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Domain.Domain.Validators
{
    public class PedidoUpdtadeDTOValidation : AbstractValidator<PedidoUpdateDTO>
    {
        public PedidoUpdtadeDTOValidation()
        {
            Include(new PedidoDTOValidation());
            RuleFor(p => p.Idpedido).NotNull().NotEmpty().WithMessage("O Id pedido não pode ser vazio.");
        }
    }
}
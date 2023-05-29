using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PedidoWebApi.Domain.Domain.DTO;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Domain.Domain.Validators
{
    public class PedidoDTOValidation : AbstractValidator<PedidoDTO>
    {
        public PedidoDTOValidation()
        {
            RuleFor(p => p.ClienteId).NotNull().WithMessage("O Id do Cliente não pode ser vazio.");
            RuleFor(a =>a.Products).NotNull().NotEmpty().WithMessage("Não pode ser vazio.");
        }
    }
}
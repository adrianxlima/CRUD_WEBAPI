using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Domain.Domain.Validators
{
    public class ClienteDTOValidation :  AbstractValidator<ClienteDTO>
    {
         public ClienteDTOValidation()
         {
            RuleFor(n => n.Nome).NotNull().NotEmpty().WithMessage("Tem que ter um Nome neste campo.");
            RuleFor(i => i.id).NotNull().NotEmpty().WithMessage("o Id não pode ser vazio.");
         }
    }
}
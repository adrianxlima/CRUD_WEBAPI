using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace PedidoWebApi.Domain.Domain.DTO
{
    public class CreditCardValidation : AbstractValidator<CreditCard>
    {
        public CreditCardValidation()
        {   
            RuleFor(dto => dto.CardName)
            .NotEmpty().NotNull().WithMessage("Este Campo não pode ser vazio");
            
        }
    }
}
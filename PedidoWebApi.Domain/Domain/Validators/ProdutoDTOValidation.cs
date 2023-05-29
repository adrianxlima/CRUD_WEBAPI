using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PedidoWebApi.Domain.Domain.DTO;
using ProjetoWebApi.Domain;

namespace PedidoWebApi.Domain.Domain.Validators
{
    public class ProdutoDTOValidation : AbstractValidator<ProdutoDTO>
    {
        public ProdutoDTOValidation()
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().WithMessage("O nome não pode ser vazio.");
            RuleFor(q => q.Quantidade).GreaterThan(0).WithMessage("A quantidade tem que ser maior que 0");

        }
    }
}
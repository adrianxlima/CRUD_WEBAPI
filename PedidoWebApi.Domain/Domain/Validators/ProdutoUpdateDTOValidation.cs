using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PedidoWebApi.Domain.Domain.DTO;

namespace PedidoWebApi.Domain.Domain.Validators
{
    public class ProdutoUpdateDTOValidation : AbstractValidator<ProdutoUpdateDTO>
    {
        public ProdutoUpdateDTOValidation()
        {
            Include(new ProdutoDTOValidation());
            RuleFor(p => p.Idproduto).NotNull().NotEmpty().WithMessage("O Id pedido não pode ser vazio.");
        }
    }
}
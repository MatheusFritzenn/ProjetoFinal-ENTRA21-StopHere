using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validations
{
    internal class ParkingValidation : AbstractValidator<Parking>
    {
        public ParkingValidation()
        {
            RuleFor(p => p.Cidade).NotNull().NotEmpty().WithMessage("Cidade deve ser informada.");
            RuleFor(p => p.Cidade).MaximumLength(40).WithMessage("Cidade deve conter até 40 caracteres.");

            RuleFor(p => p.Bairro).NotNull().NotEmpty().WithMessage("Bairro deve ser informado.");
            RuleFor(p => p.Bairro).MaximumLength(40).WithMessage("Bairro deve conter até 40 caracteres.");

            RuleFor(p => p.Rua).NotNull().NotEmpty().WithMessage("Rua deve ser informada.");
            RuleFor(p => p.Rua).MaximumLength(40).WithMessage("Rua deve conter até 40 caracteres.");

            RuleFor(p => p.Rua).NotNull().NotEmpty().WithMessage("Rua deve ser informada.");
            RuleFor(p => p.Rua).MaximumLength(40).WithMessage("Rua deve conter até 40 caracteres.");

            RuleFor(p => p.Numero).NotNull().NotEmpty().WithMessage("Número deve ser informado.");
            RuleFor(p => p.Numero).MaximumLength(5).WithMessage("Número deve conter até 40 caracteres.");

            RuleFor(p => p.CEP).NotNull().NotEmpty().WithMessage("CEP deve ser informado.");
            RuleFor(p => p.CEP).MaximumLength(8).WithMessage("CEP deve conter até 8 caracteres.");

            RuleFor(p => p.UF).NotNull().NotEmpty().WithMessage("UF deve ser informado.");

            RuleFor(p => p.Abre).NotNull().NotEmpty().WithMessage("Horário de abertura da vaga deve ser informada.");

            RuleFor(p => p.Fecha).NotNull().NotEmpty().WithMessage("Horário de fechamento da vaga deve ser informada.");

            RuleFor(p => p.Valor).NotNull().NotEmpty().WithMessage("Necessário informar o valor.");

        }
    }
}
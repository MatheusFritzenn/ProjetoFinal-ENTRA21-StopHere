using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validations
{
    internal class VehicleValidation : AbstractValidator<Vehicle>
    {
        public VehicleValidation(bool isCreateMethod)
        {
            if (isCreateMethod)
            {

                RuleFor(v => v.Placa).NotNull().NotEmpty().WithMessage("Placa do veículo deve ser informada.");
                RuleFor(v => v.Placa).MinimumLength(7).MaximumLength(8).WithMessage("Placa do veículo deve conter de 7 a 8 caracteres.");
                //RuleFor(v => v.Placa).Custom((a, b) =>
                //{
                //    if (!CustomValidations.IsValidPlaca(a))
                //    {
                //        b.AddFailure("Placa inválida.");
                //    }
                //});
            }
            RuleFor(v => v.Modelo).NotNull().NotEmpty().WithMessage("Modelo do veículo deve ser informada.");
            RuleFor(v => v.Modelo).MaximumLength(40).WithMessage("Modelo do veículo deve conter até 40 caracteres.");

            RuleFor(v => v.Cor).NotNull().NotEmpty().WithMessage("Cor do veículo deve ser informada.");

            RuleFor(v => v.TamanhoVeiculo).NotNull().NotEmpty().WithMessage("Tamanho do veículo deve ser informado.");

            RuleFor(v => v.TipoVeiculo).NotNull().NotEmpty().WithMessage("Tipo do veículo deve ser informado.");

            RuleFor(v => v.Observacao).MaximumLength(100).WithMessage("A observação deve conter até 100 caracteres.");

          
        }
    }
}


using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validations
{
    internal class LegalPersonValidation : AbstractValidator<LegalPerson>
    {
        public LegalPersonValidation(bool isCreateMethod)
        {
            if (isCreateMethod)
            {
                RuleFor(lp => lp.CNPJ).NotNull().NotEmpty().WithMessage("CNPJ deve ser informado.");
                RuleFor(lp => lp.CNPJ).MinimumLength(14).MaximumLength(20).WithMessage("CNPJ deve conter 14 caracteres");
                RuleFor(lp => lp.CNPJ).Custom((a, b) =>
                {
                    if (!CustomValidations.IsValidCNPJ(a))
                    {
                        b.AddFailure("CNPJ inválido");
                    }
                });
                RuleFor(lp => lp.InscricaoEstadual).NotNull().NotEmpty().WithMessage("Inscrição Estadual deve ser informado.");
                RuleFor(lp => lp.InscricaoEstadual).MinimumLength(9).MaximumLength(15).WithMessage("Inscrição Estadual deve conter entre 9 e 15 caracteres.");
            }

            RuleFor(lp => lp.RazaoSocial).NotNull().NotEmpty().WithMessage("Razão Social deve ser informada.");
            RuleFor(lp => lp.RazaoSocial).MaximumLength(100).WithMessage("Razão Social não pode conter mais de 100 caracteres.");

            RuleFor(lp => lp.NomeFantasia).MaximumLength(100).WithMessage("Nome Fantasia não pode conter mais de 100 caracteres.");

            RuleFor(lp => lp).SetValidator(new UserValidation(true));
        }
    }
}

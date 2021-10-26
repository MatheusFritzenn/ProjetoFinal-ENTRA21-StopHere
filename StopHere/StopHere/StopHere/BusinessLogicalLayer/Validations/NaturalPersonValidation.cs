using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validations
{
    internal class NaturalPersonValidation : AbstractValidator<NaturalPerson>
    {
        public NaturalPersonValidation(bool isCreateMethod)
        {

            if (isCreateMethod)
            {
                RuleFor(np => np.CPF).NotEmpty().WithMessage("CPF deve ser informado.");
                RuleFor(np => np.CPF).MinimumLength(11).MaximumLength(11).WithMessage("CPF deve conter 11 caracteres.");
                RuleFor(np => np.CPF).Custom((a, b) =>
                {
                    if (!CustomValidations.IsValidCPF(a))
                    {
                        b.AddFailure("CPF inválido.");
                    }
                });
            }
            
            RuleFor(np => np.Nome).NotEmpty().WithMessage("Nome deve ser informado.");
            RuleFor(np => np.Nome).Length(3, 70).WithMessage("Nome deve conter entre 3 e 70 caracteres.");
            RuleFor(np => np).SetValidator(new UserValidation(true));

        }
    }
}

using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validations
{
    internal class UserValidation : AbstractValidator<User>
    {
        public UserValidation(bool isCreateMethod)
        {
            if (isCreateMethod)
            {
                RuleFor(u => u.Email).NotNull().NotEmpty().WithMessage("Email deve ser informado.");
                RuleFor(u => u.Email).MaximumLength(100).WithMessage("Email deve conter até 100 caracteres.");
            }


            RuleFor(u => u.Bairro).NotNull().NotEmpty().WithMessage("Bairro deve ser informado.");
            RuleFor(u => u.Bairro).MaximumLength(100).WithMessage("Bairro deve conter até 100 caracteres.");

            RuleFor(u => u.Cidade).NotNull().NotEmpty().WithMessage("Cidade deve ser informado.");
            RuleFor(u => u.Cidade).MaximumLength(100).WithMessage("Cidade deve conter até 100 caracteres.");

            RuleFor(u => u.Rua).NotNull().NotEmpty().WithMessage("Rua deve ser informado.");
            RuleFor(u => u.Rua).MaximumLength(100).WithMessage("Rua deve conter até 100 caracteres.");

            RuleFor(u => u.Numero).NotNull().NotEmpty().WithMessage("O número deve ser informado.");
            RuleFor(u => u.Numero).MaximumLength(6).WithMessage("O número deve conter até 6 caracteres.");

            RuleFor(u => u.Telefone).MaximumLength(15).WithMessage("O número de telefone deve conter até 15 caracteres.");

            RuleFor(u => u.Senha).MinimumLength(6).WithMessage("A senha deve conter no minimo 6 caracteres");


        }

    }
}

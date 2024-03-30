using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Validations
{
    public class EmailValidation : AbstractValidator<EmailInputDTO>
    {
        public EmailValidation()
        {
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("Nome vazio")
                .MaximumLength(100).WithMessage("Nome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Nome muito deve ter mais de 2 caracteres");

            RuleFor(e => e.Body)
                .NotNull().WithMessage("Nome vazio")
                .MaximumLength(2000).WithMessage("Sobrenome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Sobrenome muito deve ter mais de 2 caracteres");
        }
    }
}

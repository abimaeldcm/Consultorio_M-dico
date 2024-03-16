using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class PatientValidation : AbstractValidator<PatientInputDTO>
    {
        public PatientValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Nome vazio")
                .MaximumLength(100).WithMessage("Nome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Nome muito deve ter mais de 2 caracteres");

            RuleFor(e => e.LastName)
                .NotNull().WithMessage("Nome vazio")
                .NotEqual(x => x.Name).WithMessage("Sobrenome não pode ser igual ao nome")
                .MaximumLength(100).WithMessage("Sobrenome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Sobrenome muito deve ter mais de 2 caracteres");

            RuleFor(e => e.BirthDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Data de nascimento não pode ser maior que a data atual");

            RuleFor(e => e.PhoneNumber)
                .MaximumLength(50).WithMessage("Email muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Email muito deve ter mais de 2 caracteres");

            RuleFor(e => e.Email)
                .EmailAddress().WithMessage("O formato do e-mail está incorreto")
                .MaximumLength(100).WithMessage("Email muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Email muito deve ter mais de 2 caracteres");

            RuleFor(e => e.CPF.Length)
                .InclusiveBetween(11, 14).WithMessage("CPF não está entre 11 e 14");

            RuleFor(e => e.BloodType).IsInEnum().WithMessage("Opção inválida");

            RuleFor(e => e.Address)
                .MaximumLength(100).WithMessage("Nome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Nome muito deve ter mais de 2 caracteres");
        }
    }
}

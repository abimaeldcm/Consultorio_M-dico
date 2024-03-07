using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class MedicoValidation : AbstractValidator<MedicoInputDTO>
    {
        public MedicoValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("Nome vazio")
                .MaximumLength(100).WithMessage("Nome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Nome muito deve ter mais de 2 caracteres");
            RuleFor(e => e.Sobrenome)
                .NotNull().WithMessage("Nome vazio")
                .NotEqual(x => x.Nome).WithMessage("Sobrenome não pode ser igual ao nome")
                .MaximumLength(100).WithMessage("Sobrenome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Sobrenome muito deve ter mais de 2 caracteres");
            RuleFor(e => e.DataNascimento)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Data de nascimento não pode ser maior que a data atual");
            RuleFor(e => e.Telefone)
                .MaximumLength(50).WithMessage("Email muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Email muito deve ter mais de 2 caracteres");
            RuleFor(e => e.Email)
                .EmailAddress().WithMessage("O formato do e-mail está incorreto")
                .MaximumLength(100).WithMessage("Email muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Email muito deve ter mais de 2 caracteres");
            RuleFor(e => e.CPF.Length)
                .InclusiveBetween(11, 14).WithMessage("CPF não está entre 11 e 14"); 
            RuleFor(e => e.TipoSanguineo).IsInEnum().WithMessage("Opção inválida");
            RuleFor(e => e.Endereco)
                .MaximumLength(100).WithMessage("Nome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Nome muito deve ter mais de 2 caracteres");
            RuleFor(e => e.RegistroCRM)
                .Matches("^\\d{5}/[A-Z]{2}$\r\n")
                .WithMessage("CRM no formato errado");



        }
    }
}

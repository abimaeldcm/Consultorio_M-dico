using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class ServicoValidation : AbstractValidator<ServiceInputDTO>
    {
        public ServicoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .MinimumLength(2).WithMessage("Nome tem que ser maior que 1 caracteres")
                .MaximumLength(100).WithMessage("Nome deve ser menor que 100 caracteres");

            RuleFor(x => x.Description)
                .MinimumLength(2).WithMessage("Descrição tem que ser maior que 1 caracteres")
                .MaximumLength(100).WithMessage("Descrição deve ser menor que 300 caracteres"); ;

            RuleFor(x => x.Value)
                .PrecisionScale(8, 2, false).WithMessage("Valor inválido: muito extenso");

            RuleFor(x => x.Duration).InclusiveBetween(1, 1000).WithMessage("Duração deve estar entre 1 e 1000");
        }
    }
}

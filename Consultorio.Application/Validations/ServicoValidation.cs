using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class ServicoValidation : AbstractValidator<ServicoInputDTO>
    {
        public ServicoValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .MinimumLength(2).WithMessage("Nome tem que ser maior que 1 caracteres")
                .MaximumLength(100).WithMessage("Nome deve ser menor que 100 caracteres");
            RuleFor(x => x.Descricao)
                .MinimumLength(2).WithMessage("Descrição tem que ser maior que 1 caracteres")
                .MaximumLength(100).WithMessage("Descrição deve ser menor que 300 caracteres"); ;
            RuleFor(x => x.Valor)
                .PrecisionScale(8, 2, false).WithMessage("Valor inválido: muito extenso");
            RuleFor(x => x.Duracao).InclusiveBetween(1, 1000).WithMessage("Duração deve estar entre 1 e 1000");
        }
    }
}

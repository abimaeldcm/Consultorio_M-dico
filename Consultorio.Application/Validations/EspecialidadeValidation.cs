using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using FluentValidation;

namespace Consultorio.Application.Validations
{
    public class EspecialidadeValidation : AbstractValidator<EspecialidadeInputDTO>
    {
        public EspecialidadeValidation()
        {
            RuleFor(e => e.EspecialidadeMedica)
                .Length(100)
                .WithMessage("Especialidade com o nome muito grande");
        }
    }
}
